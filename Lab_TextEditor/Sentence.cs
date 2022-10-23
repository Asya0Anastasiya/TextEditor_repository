using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_TextEditor
{
    [Serializable]
    
    public class Sentence : IComparable<Sentence>
    {
        public Sentence() { }

        public List<char> pun = new List<char>();

        [XmlIgnore]
        public List<Punctuation> punctuations = new List<Punctuation>();

        public static List<string> array = new List<string>();
        public enum Sentencetype { a, b, c }

        public Sentencetype type;

        public int CompareTo(Sentence other)
        {
            if (this.Length() < other.Length())
            {
                return 1;
            }
            else if (this.Length() > other.Length())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        [XmlIgnore]
        public List<Word> Words = new();

        [XmlIgnore]
        public int AmountOfWords { get {return Words.Count();} }

        public int Length() //Length
        {
            int length = 0;
            for (int i = 0; i < AmountOfWords; ++i)
            {
                length += Words[i].Length;
            }
            return length + (AmountOfWords - 1) + punctuations.Count();
        }
        public override string ToString()  //ToString()
        {
            string result = "";
            int count = 0;
            for(int i = 0; i < AmountOfWords; ++i)
            {
                result += Words[i].str;
                if (Words[i].havePuncMark)
                {
                    //result += punctuations[count].mark;
                    //result += pun[count];
                    result += Words[i].Punct;
                    count++;
                }
                result += ' ';
            }
            return result;
        }
        public void Remove(int length, string lang)  //Remove
        {
            for(int i = 0; i < AmountOfWords; ++i)
            {
                if (Words[i].isSutiable(lang) && Words[i].Length == length)
                {
                    Words.Remove(Words[i]);
                } 
            }
        }
        public void Replace(int length, string substring) // fghj fgh gh
        {
            for (int i = 0; i < AmountOfWords; ++i)
            {
                if (Words[i].Length == length)
                {
                    Words.RemoveAt(i);
                    Word word = new Word();
                    word.str = substring;
                    Words.Insert(i, word);
                }
            }
        }
        
        public bool Check(List<string> words, string token)
        {
            for(int i = 0; i < words.Count; ++i)
            {
                if (words[i] == token) return true;
            }
            return false;
        }
        public List<string> Interrogative(int length)
        {
            
            for(int i = 0; i < AmountOfWords; ++i)
            {
                if(Words[i].Length == length && Check(array, Words[i].str) == false)
                {
                    array.Add(Words[i].str);
                }
            }
            return array;
        }
    }
}
