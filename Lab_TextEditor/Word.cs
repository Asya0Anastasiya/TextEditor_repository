using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_TextEditor
{
    [Serializable]
    public class Word
    {
        public Word() { }
        [XmlIgnore]
        public string str;
        private char punct;
        public char Punct {get { return punct; } set{ punct = value; } }
       [XmlIgnore]
        public bool havePuncMark;
        public int Length { get {return str.Length; } }
        string[] vowels;
        public bool isSutiable(string lang)
        {
            if(lang == "RU") vowels = new string[] { "у", "е", "ы", "а", "э", "я", "и", "ю", "о", "ё" };
            else vowels = new string[] { "a", "e", "u", "i", "o" };
            
            foreach (string vowel in vowels)
            {
                if (str.StartsWith(vowel)) return false;
            }
            return true;
        }
    }
}
