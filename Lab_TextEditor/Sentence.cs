using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_TextEditor
{
    class Sentence : Punctuation, IComparable<Sentence>
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
        public List<Word> WordsList = new();
       // public int amountOfPunc = 0;
        public int countWords()
        {
            return WordsList.Count();
        }
        public int sentenceLength()
        {
            int length = 0;
            for (int i = 0; i < countWords(); ++i)
            {
                length += WordsList[i].wordLength();
            }
            return length + (countWords() - 1) + punctuations.Count();
        }
        public string buildSentence()
        {
            string result = "";
            int count = 0;
            for(int i = 0; i < countWords(); ++i)
            {
                result += WordsList[i].str;
                if (WordsList[i].havePuncMark)
                {
                    result += punctuations[count].mark;
                    count++;
                }
                result += ' ';
            }
            return result;
        }
        public void removeWords(int length)
        {
            for(int i = 0; i < countWords(); ++i)
            {
                if (WordsList[i].isSutiable() && WordsList[i].wordLength() == length)
                {
                    WordsList.Remove(WordsList[i]);
                } 
            }
        }
        public void replaceWords(int length, string substring)
        {
            for (int i = 0; i < countWords(); ++i)
            {
                if (WordsList[i].wordLength() == length)
                {
                    WordsList.RemoveAt(i);
                    Word word = new();
                    word.str = substring;
                    WordsList.Insert(i, word);
                }
            }
        }
    }
}
