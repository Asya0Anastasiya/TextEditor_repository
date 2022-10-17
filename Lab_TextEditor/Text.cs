using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_TextEditor
{
    class Text
    {
        public List<Sentence> SentencesList = new();
        //public void PrintElements()
        //{
        //    for(int i = 0; i < SentencesList.Count; ++i)
        //    {
        //        for(int j = 0; j < SentencesList[i].WordsList.Count; ++j)
        //        {
        //            Console.WriteLine(SentencesList[i].WordsList[j].str);
        //        }
        //    }
        //}
        //public void PrintCounts()
        //{
        //    for (int i = 0; i < SentencesList.Count; ++i)
        //    {
        //        Console.WriteLine(SentencesList[i].countWords());
        //    }
        //}
        //public void PrintCountsLetters()
        //{
        //    for (int i = 0; i < SentencesList.Count; ++i)
        //    {
        //        Console.WriteLine(SentencesList[i].sentenceLength());
        //    }
        //}
        public void PrintSentences()
        {
            for (int i = 0; i < SentencesList.Count; ++i)
            {
                //SentencesList[i].replaceWords(4, "!!!");
                //SentencesList[i].removeWords(4);
                Console.WriteLine(SentencesList[i].buildSentence());
            }
        }
    }
}
