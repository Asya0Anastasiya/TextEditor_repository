using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_TextEditor
{
    class Parser
    {
        Text text = new Text();
        Sentence sentence = new Sentence();
        Word word = new Word();
        //XmlSerializer formatter = new XmlSerializer(typeof(List<Sentence>));

        public Text ReadText()  //path as parameter
        {
             string path = @"C:\Users\Administrator\source\repos\C#\3rd semester\Lab_TextEditor\song.txt";
            string song = System.IO.File.ReadAllText(path);
            for (int i = 0; i < song.Length; ++i)
            {
                if (song[i] == ',' || song[i] == ';' || song[i] == ':')
                {
                    //sentence.mark = song[i];
                    //sentence.index = i;
                    word.havePuncMark = true;
                    Punctuation punctuation = new();
                    punctuation.mark = song[i];
                    punctuation.index = i;
                    sentence.punctuations.Add(punctuation);
                    //sentence.amountOfPunc++;
                    sentence.WordsList.Add(word);
                    word = new Word();
                    continue;
                }
                else if (song[i] == ' ')
                {
                    if (word.str != null) sentence.WordsList.Add(word);
                    word = new Word();
                    continue;
                }
                else 
                if (song[i] == '.' || song[i] == '!' || song[i] == '?')
                {
                    sentence.WordsList.Add(word);
                    Punctuation punctuation = new();
                    word.havePuncMark = true;
                    punctuation.mark = song[i];
                    punctuation.index = i;
                    sentence.punctuations.Add(punctuation);
                    word = new Word();
                    text.SentencesList.Add(sentence);
                    sentence = new Sentence();
                    continue;
                }
                word.str += song[i];
            }
            return text;
        }

    }
}
