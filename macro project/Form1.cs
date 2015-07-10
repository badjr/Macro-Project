using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;

//TODO: changing the list on the fly

namespace macro_project {

    public partial class Form1 : Form {

        //--------Keylogging stuff----------
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        //private LowLevelKeyboardProc _proc = HookCallback;
        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        //These Dll's will handle the hooks. Yaaar mateys!

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // The two dll imports below will handle the window hiding.

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetConsoleWindow();

        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //const int SW_HIDE = 0;

        //--------End of Keylogging stuff----------

        private DataTable dt;

        private String currentFileName;

        private static List<Macro> macrosAndExpansions;
        BindingSource bindingSource = new BindingSource();
        private static string typedChars;

        //NotifyIcon notifyIcon;
        static int secondsSinceTyped = 0;
        static System.Windows.Forms.Timer t;

        private Boolean applicationEnabled; //We can toggle if application is enabled or not. If not enabled, macros won't be expanded.

        public Form1() {
            trackLastTypedTime();
            InitializeComponent();
            _proc = HookCallback; //Moved this from the fields to inside the constructor...
            //so I could change all the methods trying to change the non-static
            //secondsSinceLastTyped label to non-static methods.

            applicationEnabled = true;

            makeEmptyDataGridView();

            //InitializeMyScrollBar();
            //notifyIcon = new NotifyIcon();
            //notifyIcon.Visible = true;
            //notifyIcon.Icon = SystemIcons.Application;

            //-------Keylogging stuff------------

            //var handle = GetConsoleWindow();

            //// Hide
            //ShowWindow(handle, SW_HIDE);
            //These lines are neccesary for the printing of keys pressed to the console
            _hookID = SetHook(_proc);
            Application.Run(this);
            UnhookWindowsHookEx(_hookID);

            //-------End Keylogging stuff------------

            //typedChars = ""; //initialize typedChars to empty string


        }

        private void trackLastTypedTime() {
            //Console.WriteLine("Here");
            t = new System.Windows.Forms.Timer();

            t.Interval = 1000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

            //t.Stop();
        }

        private void timer_Tick(object sender, EventArgs e) {
            //Call method

            //if (secondsSinceTyped == 5) {
            //    t.Stop();
            //    secondsSinceTyped = 0;
            //    return;
            //}

            secondsSinceTyped++;

            //secondsSinceTypedLabel.Text = secondsSinceTyped.ToString();

        }

        private void saveAsButtonClick(object sender, EventArgs e) {
            doSaveAs();
        }

        private void openButton_Click(object sender, EventArgs e) {
            doOpen();
        }

        //This stuff for when keys are pressed.

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            //applicationEnabled = true;
            //Console.WriteLine("applicationEnabled = " + applicationEnabled);
            //Only expand macros if the application does not have focus.
            //We don't want to be expanding macros while we are defining them.
            if (!ApplicationIsActivated() && applicationEnabled) {
                applicationEnabled = false; //So we don't get stuck in recursive macros

                if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                    int vkCode = Marshal.ReadInt32(lParam);
                    //Console.WriteLine((Keys) vkCode);

                    //Console.WriteLine("macrosAndExpansions.Size = " + macrosAndExpansions.ElementAt(0).getSequence());


                    //If space is pressed and less than 5 seconds since last typed, we want to type out the expansion from the sequence
                    if (vkCode == (int) Keys.Space && secondsSinceTyped <= 5) {
                        //Console.WriteLine("Space!");

                        for (int i = 0; i < macrosAndExpansions.Count; i++) {
                            String currSequence = macrosAndExpansions.ElementAt(i).getSequence();

                            if (currSequence.ToUpper().Equals(typedChars)) {
                                //If expansion starts with sequence, just tack on remaining chars
                                if (macrosAndExpansions.ElementAt(i).getExpansion().StartsWith(currSequence)) {
                                    SendKeys.SendWait(macrosAndExpansions.ElementAt(i).getExpansion().Substring(currSequence.Length));

                                    //make typedChars the empty string to start over
                                    typedChars = "";
                                }
                                else {
                                    //Otherwise, backspace the length of sequence
                                    for (int j = 0; j < currSequence.Length; j++) {
                                        SendKeys.SendWait("{BS}");
                                    }
                                    //and type the expansion
                                    SendKeys.SendWait(macrosAndExpansions.ElementAt(i).getExpansion());

                                    //make typedChars the empty string to start over
                                    typedChars = "";
                                }
                            }
                        }

                        //Make typedChars blank so we can start over tracking sequences
                        typedChars = "";

                    }
                    //Else if any character other than space, we concantenate to the string typedChars which key was pressed.
                    else if (secondsSinceTyped <= 5) {


                        switch ((int) vkCode) {
                            case ((int) Keys.Back):
                                //TODO: Give option of backspacing and retaining current sequence or...
                                //typedChars = typedChars.Substring(0, typedChars.Length - 1);
                                //just starting over.
                                typedChars = "";
                                break;
                            case ((int) Keys.Enter):
                                typedChars = "";
                                break;
                            //Make meaningless keys do nothing because they add unnecesary characters to the current typed sequence
                            case ((int) Keys.CapsLock):
                            case ((int) Keys.Shift):
                            case ((int) Keys.LShiftKey):
                            case ((int) Keys.RShiftKey):
                            case ((int) Keys.Home):
                            case ((int) Keys.End):
                            case ((int) Keys.PageUp):
                            case ((int) Keys.PageDown):
                            case ((int) Keys.Insert):
                            case ((int) Keys.Delete):
                            case ((int) Keys.F1):
                            case ((int) Keys.F2):
                            case ((int) Keys.F3):
                            case ((int) Keys.F4):
                            case ((int) Keys.F5):
                            case ((int) Keys.F6):
                            case ((int) Keys.F7):
                            case ((int) Keys.F8):
                            case ((int) Keys.F9):
                            case ((int) Keys.F10):
                            case ((int) Keys.F11):
                            case ((int) Keys.F12):
                            case ((int) Keys.Alt):
                            case ((int) Keys.Control):
                            case ((int) Keys.LWin):
                            case ((int) Keys.RWin):
                                //case ((int) Keys.):
                                //case ((int) Keys.Menu):
                                break;
                            //Pressing escape resets the typed chars.
                            case ((int) Keys.Escape):
                                typedChars = "";
                                break;
                            default:
                                typedChars += (char) vkCode;
                                break;
                        }
                        //typedChars += (char) vkCode;

                        //notifyIcon.BalloonTipText += e.KeyCode.ToString();
                        //notifyIcon.ShowBalloonTip(50);
                        //typedCharsTextBox.Text += e.KeyCode.ToString();
                        secondsSinceTyped = 0;
                    }
                    //Else, it's been more than 5 seconds since last typed and we need to reset typedChars to start tracking another sequence.
                    else {
                        secondsSinceTyped = 0;
                        typedChars = ((char) vkCode) + "";
                        t.Dispose();
                        trackLastTypedTime();

                        //notifyIcon.BalloonTipText = "";
                        //notifyIcon.BalloonTipText += e.KeyCode.ToString();
                        //notifyIcon.ShowBalloonTip(50);

                        //typedCharsTextBox.Text = "";
                        //typedCharsTextBox.Text += e.KeyCode.ToString();
                    }

                    //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
                    //sw.Write((Keys) vkCode);
                    //sw.Close();
                    Console.WriteLine("typedChars = " + typedChars + ". length = " + typedChars.Length);
                }

                applicationEnabled = true; //So we don't get stuck in recursive macros

            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        //Stole this from http://stackoverflow.com/questions/7162834/determine-if-current-application-is-activated-has-focus
        /// <summary>Returns true if the current application has focus, false otherwise</summary>
        public static bool ApplicationIsActivated() {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero) {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);


        //for notification icon
        private void Form1_Resize(object sender, System.EventArgs e) {
            if (FormWindowState.Minimized == WindowState) {
                Hide();
                //Console.WriteLine("Minimized.");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender,
                                     System.EventArgs e) {
            //Console.WriteLine("I was double clicked.");
            if (WindowState == FormWindowState.Minimized) {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            doExit();
        }

        private void doExit() {
            if (System.Windows.Forms.Application.MessageLoop) {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else {
                // Console app
                System.Environment.Exit(0);
            }
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e) {
            if (applicationEnabled) {
                applicationEnabled = false;
                statusNotificationAreaToolStripMenuItem.Text = "Status: Disabled";
            }
            else {
                applicationEnabled = true;
                statusNotificationAreaToolStripMenuItem.Text = "Status: Enabled";
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            try {
                Console.WriteLine("You just changed column " + e.ColumnIndex + " row " + e.RowIndex + " to " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                macrosAndExpansions.ElementAt(e.RowIndex).setSequence((String) dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                macrosAndExpansions.ElementAt(e.RowIndex).setExpansion((String) dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (System.ArgumentOutOfRangeException ex) {
                try {
                    macrosAndExpansions.Add(new Macro((String) dataGridView1.Rows[e.RowIndex].Cells[0].Value, (String) dataGridView1.Rows[e.RowIndex].Cells[1].Value));
                }
                catch (InvalidCastException ice) {

                }
            }
        }

        private void newConfigurationToolStripMenuItem1_Click(object sender, EventArgs e) {
            makeEmptyDataGridView();
        }

        private void doOpen() {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) {

                macrosAndExpansions = new List<Macro>();

                int counter = 0;
                string line;


                //bindingSource.DataSource = typeof(Macro);

                //Set up DataTable with cols Sequence and Expansion
                dt = new DataTable();
                dt.Columns.Add("Sequence", typeof(string));
                dt.Columns.Add("Expansion", typeof(string));

                //Bind data table to bindingSource
                bindingSource.DataSource = dt;

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                while ((line = file.ReadLine()) != null) {

                    //Sequence and expansion are comma delimited
                    String[] macroAndExpansion = line.Split(",".ToCharArray());

                    //add macro to list (kept for current macro list we are working on, can be used for saving later)
                    macrosAndExpansions.Add(new Macro(macroAndExpansion[0], macroAndExpansion[1]));
                    //Console.WriteLine(macrosAndExpansions.ElementAt(1).getExpansion());

                    //Create data row and prepare to be put in the data table
                    //(crucial for getting the text to appear on the dataGridView cells.)
                    DataRow dr = dt.NewRow();
                    dr["Sequence"] = macroAndExpansion[0];
                    dr["Expansion"] = macroAndExpansion[1];

                    //Add the row to the data table
                    dt.Rows.Add(dr);

                    //Console.WriteLine(macroAndExpansion[0] + ":" + macroAndExpansion[1]);
                    //Console.WriteLine(line);
                    counter++;
                }

                //dataGridView1.DataSource = bindingSource;
                //dataGridView1.AutoGenerateColumns = true;

                //Set the dataGridView data source to bindingSource
                dataGridView1.DataSource = bindingSource;
                //dataGridView1.AutoGenerateColumns = true;

                file.Close();

                currentFileName = Path.GetFileName(openFileDialog.FileName);

                currentFileLabel.Text = "Current file: " + currentFileName;

            }
        }

        private void doSaveAs() {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {

                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());


                for (int i = 0; i < macrosAndExpansions.Count; i++) {
                    writer.WriteLine(macrosAndExpansions.ElementAt(i).getSequence() + "," + macrosAndExpansions.ElementAt(i).getExpansion());
                }

                writer.Dispose();

                writer.Close();

                currentFileName = Path.GetFileName(saveFileDialog1.FileName);

                currentFileLabel.Text = "Current file: " + currentFileName;

            }

        }

        private void doSaveConfiguration() {

            if (currentFileName == null) {
                doSaveAs();
            }

            else {

                StreamWriter writer = new StreamWriter(currentFileName);

                for (int i = 0; i < macrosAndExpansions.Count; i++) {
                    writer.WriteLine(macrosAndExpansions.ElementAt(i).getSequence() + "," + macrosAndExpansions.ElementAt(i).getExpansion());
                }

                writer.Dispose();

                writer.Close();

            }
        }

        private void makeEmptyDataGridView() {
            macrosAndExpansions = new List<Macro>();

            dt = new DataTable();
            dt.Columns.Add("Sequence", typeof(string));
            dt.Columns.Add("Expansion", typeof(string));

            //Bind data table to bindingSource
            bindingSource.DataSource = dt;

            dataGridView1.DataSource = bindingSource;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e) {
            doSaveConfiguration();
        }

        private void openConfigurationToolStripMenuItem1_Click(object sender, EventArgs e) {
            doOpen();
        }

        private void saveConfigurationAsToolStripMenuItem_Click(object sender, EventArgs e) {
            doSaveAs();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            doExit();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e) {
            if (applicationEnabled) {
                applicationEnabled = false;
                statusFileMenuToolStripMenuItem.Text = "Status: Disabled";
            }
            else {
                applicationEnabled = true;
                statusFileMenuToolStripMenuItem.Text = "Status: Enabled";
            }
        }

        private void notificationAreaContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            if (applicationEnabled) {
                statusNotificationAreaToolStripMenuItem.Text = "Status: Enabled";
            }
            else {
                statusNotificationAreaToolStripMenuItem.Text = "Status: Disabled";
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (applicationEnabled) {
                statusFileMenuToolStripMenuItem.Text = "Status: Enabled";
            }
            else {
                statusFileMenuToolStripMenuItem.Text = "Status: Disabled";
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }
    }
}