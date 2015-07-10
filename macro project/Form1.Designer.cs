using System.Windows.Forms;
using System;
namespace macro_project {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationAreaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusNotificationAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigurationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigurationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusFileMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.notificationAreaContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(24, 57);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(448, 430);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.AutoSize = true;
            this.currentFileLabel.Location = new System.Drawing.Point(21, 33);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(60, 13);
            this.currentFileLabel.TabIndex = 11;
            this.currentFileLabel.Text = "Current file:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notificationAreaContextMenuStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Macro Project";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notificationAreaContextMenuStrip
            // 
            this.notificationAreaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusNotificationAreaToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notificationAreaContextMenuStrip.Name = "contextMenuStrip2";
            this.notificationAreaContextMenuStrip.Size = new System.Drawing.Size(155, 48);
            this.notificationAreaContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.notificationAreaContextMenuStrip_Opening);
            // 
            // statusNotificationAreaToolStripMenuItem
            // 
            this.statusNotificationAreaToolStripMenuItem.Name = "statusNotificationAreaToolStripMenuItem";
            this.statusNotificationAreaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.statusNotificationAreaToolStripMenuItem.Text = "Status: Enabled";
            this.statusNotificationAreaToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigurationToolStripMenuItem1,
            this.newConfigurationToolStripMenuItem1,
            this.saveConfigurationToolStripMenuItem,
            this.saveConfigurationAsToolStripMenuItem,
            this.statusFileMenuToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openConfigurationToolStripMenuItem1
            // 
            this.openConfigurationToolStripMenuItem1.Name = "openConfigurationToolStripMenuItem1";
            this.openConfigurationToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.openConfigurationToolStripMenuItem1.Text = "Open Configuration";
            this.openConfigurationToolStripMenuItem1.Click += new System.EventHandler(this.openConfigurationToolStripMenuItem1_Click);
            // 
            // newConfigurationToolStripMenuItem1
            // 
            this.newConfigurationToolStripMenuItem1.Name = "newConfigurationToolStripMenuItem1";
            this.newConfigurationToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.newConfigurationToolStripMenuItem1.Text = "New Configuration";
            this.newConfigurationToolStripMenuItem1.Click += new System.EventHandler(this.newConfigurationToolStripMenuItem1_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // saveConfigurationAsToolStripMenuItem
            // 
            this.saveConfigurationAsToolStripMenuItem.Name = "saveConfigurationAsToolStripMenuItem";
            this.saveConfigurationAsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveConfigurationAsToolStripMenuItem.Text = "Save Configuration As...";
            this.saveConfigurationAsToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationAsToolStripMenuItem_Click);
            // 
            // statusFileMenuToolStripMenuItem
            // 
            this.statusFileMenuToolStripMenuItem.Name = "statusFileMenuToolStripMenuItem";
            this.statusFileMenuToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.statusFileMenuToolStripMenuItem.Text = "Status: Enabled";
            this.statusFileMenuToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // macroBindingSource
            // 
            this.macroBindingSource.DataSource = typeof(macro_project.Macro);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(macro_project.Program);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 499);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.currentFileLabel);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "macro project";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.notificationAreaContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeMyScrollBar() {
            // Create and initialize a VScrollBar.
            VScrollBar myvScrollBar1 = new VScrollBar();

            // Dock the scroll bar to the right side of the form.
            myvScrollBar1.Dock = DockStyle.Right;

            // Add the scroll bar to the form.
            Controls.Add(myvScrollBar1);

            //vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            //myvScrollBar1.Scroll += (sender, e) => { splitContainer1.VerticalScroll.Value = myvScrollBar1.Value; };
            myvScrollBar1.Enabled = true;
            //splitContainer1.Scroll

        }

        private void addItem() {
            
        }

        //public static void setSecondsSinceLastTypedLabel(String s) {
        //    secondsSinceTypedLabel.Text = s;
        //}

        public String getDataGrid() {
            return dataGridView1.Rows[2].Cells[2].Value.ToString();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label currentFileLabel;
        private BindingSource programBindingSource;
        private BindingSource macroBindingSource;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip notificationAreaContextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem statusNotificationAreaToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newConfigurationToolStripMenuItem1;
        private ToolStripMenuItem openConfigurationToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private ToolStripMenuItem saveConfigurationAsToolStripMenuItem;
        private ToolStripMenuItem statusFileMenuToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}

