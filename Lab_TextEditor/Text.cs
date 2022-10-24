using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_TextEditor
{
    [Serializable]
    public class Text
    {
        public Text() { }
        [XmlIgnore]
        public static string Lang;
        
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
                //SentencesList[i].Replace(4, "!!!");
                //SentencesList[i].Remove(4,Lang);
                Console.WriteLine(SentencesList[i]);
            }
        }
        private static List<string> readFile(string path)
        {
            List<string> text = new List<string>();
            StreamReader reader = new StreamReader(path);
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                if ((str = str.Trim()).Length != 0)
                    text.Add(str);
            }
            reader.Close();
            return text;
        }

       
        public void DeleteStopWords()
        {
            List<string> stopWords;
            if (Lang == "Ru") stopWords = readFile("stopWordsRu.txt");
            else stopWords = readFile("stopWordsEn.txt");
            for (int i = 0; i < SentencesList.Count; ++i)
            {
                for (int j = 0; j < SentencesList[i].Words.Count; ++j)
                {
                    if(stopWords.Contains(SentencesList[i].Words[j].str))
                    {
                        SentencesList[i].Words.RemoveAt(j);
                    }
                }
            }
        }

        public void Print(List<string> words)
        {
            for(int i = 0; i < words.Count; ++i)
            {
                Console.WriteLine(words[i]);
            }
        }
        public void PrintWords()
        {
            for (int i = 0; i < SentencesList.Count; ++i)
            {
                if (SentencesList[i].type == Sentence.Sentencetype.c)
                {
                    SentencesList[i].Interrogative(4);
                }
            }
            Print(Sentence.array);
        }
    }
}
