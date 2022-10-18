using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_TextEditor
{
    class Sentence : IComparable<Sentence>
    {
        public List<Punctuation> punctuations = new List<Punctuation>();
        public int CompareTo(Sentence other)
        {
            if (this.sentenceLength() < other.sentenceLength())
            {
                return 1;
            }
            else if (this.sentenceLength() > other.sentenceLength())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public List<Word> Words = new();

        public int AmountOfWords { get {return Words.Count();} }
        public int sentenceLength() //Length
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
                    result += punctuations[count].mark;
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
                    Word word = new();
                    word.str = substring;
                    Words.Insert(i, word);
                }
            }
        }
    }
}
