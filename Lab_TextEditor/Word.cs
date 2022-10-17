using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_TextEditor
{
    class Word
    {
        public string str;
        public bool havePuncMark;
        public int wordLength()
        {
            return str.Length;
        }

        public bool isSutiable()
        {
            //bool result = true;
            string[] vowels = new string[] { "a", "e", "u", "i", "o" };
            foreach(string vowel in vowels)
            {
                if (str.StartsWith(vowel)) return false;
            }
            return true;
        }
    }
}
