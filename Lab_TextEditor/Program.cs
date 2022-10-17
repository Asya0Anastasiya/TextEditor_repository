using System;

namespace Lab_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            //string path = @"C:\Users\Administrator\source\repos\Lab_TextEditor\song.txt";
            
            Text text = parser.ReadText();
            //text.PrintElements();
            text.SentencesList.Sort();
            //text.PrintCountsLetters();
            text.PrintSentences();
        }
    }
}
