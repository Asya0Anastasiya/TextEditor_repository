using System;
using System.Xml.Serialization;
using System.IO;
namespace Lab_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            Text.Lang = "RU";
            Text text = parser.ReadText();
            //XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            //XmlAttributes attribs = new XmlAttributes();
            //attribs.XmlIgnore = true;
            //attribs.XmlElements.Add(new XmlElementAttribute("Words"));
            //overrides.Add(typeof(Text), "Words", attribs);


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Text));
            using (FileStream fs = new FileStream("text.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, text);

                Console.WriteLine("Object has been serialized");
            }
            text.DeleteStopWords();
            //text.PrintElements();
            //text.SentencesList.Sort();
            //text.PrintSentences();
            //text.PrintWords();
            text.PrintSentences();
            
        }
    }
}
