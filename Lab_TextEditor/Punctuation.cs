using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_TextEditor
{

    public class Punctuation
    {
        //public string Dot = ".";
        //public string Comma = ",";
        //public string ExclamationMark = "!";
        //public string QuestionMark = "?";
        [XmlIgnore]
        public char mark;
        [XmlIgnore]
        public int index;
    }
}
