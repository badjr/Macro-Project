using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace macro_project {
//    class Macro {
//        private string _sequence;
//        private string _expansion;

//        public Macro(string sequence, string expansion) {
//            _sequence = sequence;
//            _expansion = expansion;
//        }

//        public string Sequence {
//            get;
//            set;
//        }

//        public string Expansion {
//            get;
//            set;
//        }

//    }
//}

namespace macro_project {
    class Macro {
        private string sequence;
        private string expansion;

        public Macro(string sequence, string expansion) {
            this.sequence = sequence;
            this.expansion = expansion;
        }

        public string getSequence() {
            return sequence;
        }

        public string getExpansion() {
            return expansion;
        }

        public void setSequence(String sequence) {
            this.sequence = sequence;
        }

        public void setExpansion(String expansion) {
            this.expansion = expansion;
        }

    }
}
