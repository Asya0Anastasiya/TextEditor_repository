using System;
namespace Lab_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            //string path = @"C:\Users\Administrator\source\repos\Lab_TextEditor\song.txt";

            Text.Lang = "RU";
            Text text = parser.ReadText();
            text.deleteStopWords();
            //text.PrintElements();
            //text.SentencesList.Sort();
            text.PrintSentences();
            
        }
    }
}
