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
       // public Punctuation {get {} }
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
