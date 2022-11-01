using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_TextEditor
{
    public static class Extensions
    {
        public static SortedDictionary<TKey, TValue> SortByKey<TKey, TValue>(
                            this IDictionary<TKey, TValue> dict)
        {
            return new SortedDictionary<TKey, TValue>(dict);
        }
    }

    class Parser
    {
        Text text = new Text();
        Sentence sentence = new Sentence();
        Word word = new Word();
        public int line = 1;
        Dictionary<string, SortedSet<int>> concordance = new Dictionary<string, SortedSet<int>>();

        public void AddToDictionary()
        {
            if (concordance.ContainsKey(word.str.ToLower()))
            {
                concordance[word.str.ToLower()].Add(line);
            }
            else
            {
                SortedSet<int> list = new SortedSet<int>();
                list.Add(line);
                concordance.Add(word.str.ToLower(), list);
            }
        }
        public string PrintList(SortedSet<int> list)
        {
            string result = "";
            foreach(int el in list)
            {
                result += el.ToString() + " ";
            }
            return result;
        }


        public void PrintDict()
        {
            var sortedDict = concordance.SortByKey();
            foreach (var pair in sortedDict)
            {
                Console.WriteLine($"{pair.Key}...............{pair.Value.Count}: {PrintList(pair.Value)}");
            }
            
        }
        public Text ReadText()  //path as parameter
        {
            
            string path = @"C:\Users\Administrator\source\repos\C#\3rd semester\Lab_TextEditor\song.txt";
            string song = System.IO.File.ReadAllText(path);
            for (int i = 0; i < song.Length; ++i)
            {
                if (song[i] == '\n')
                {
                    line++;
                }
                if (song[i] == ',' || song[i] == ';' || song[i] == ':')
                {
                    //sentence.mark = song[i];
                    //sentence.index = i;
                    word.havePuncMark = true;
                    word.Punct = song[i];
                    //Punctuation punctuation = new();
                   // punctuation.mark = song[i];
                    sentence.pun.Add(song[i]);
                    //punctuation.index = i;
                    //sentence.punctuations.Add(punctuation);
                    //sentence.amountOfPunc++;
                    sentence.Words.Add(word);
                    AddToDictionary();
                    word = new Word();
;                   continue;
                }
                else if (song[i] == ' ')
                {
                    if (word.str != null) 
                    {
                        sentence.Words.Add(word);
                        AddToDictionary();
                    }
                    word = new Word();
                    continue;
                }
                else if (song[i] == '.' || song[i] == '!' || song[i] == '?')
                {
                    sentence.Words.Add(word);
                    AddToDictionary();
                    sentence.pun.Add(song[i]);

                    //Punctuation punctuation = new();
                    switch (song[i])
                    {
                        case '.':
                            sentence.type = Sentence.Sentencetype.a;
                            break;
                        case '!':
                            sentence.type = Sentence.Sentencetype.b;
                            break;
                        case '?':
                            sentence.type = Sentence.Sentencetype.c;
                            break;
                        default:
                            break;
                    }
                    word.havePuncMark = true;
                    word.Punct = song[i];
                   // punctuation.mark = song[i];
                   // punctuation.index = i;
                   // sentence.punctuations.Add(punctuation);
                    word = new Word();
                    text.SentencesList.Add(sentence);
                    sentence = new Sentence();
                    continue;
                }
                word.str += song[i];
            }
            PrintDict();
            return text;
        }

    }
}
