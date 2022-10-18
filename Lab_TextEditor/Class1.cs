using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Lab_TextEditor
{
    public static class XmlTools
    {
        // Return obj's serialization as a string.
        public static string Serialize<T>(T obj)
        {
            // Create a serializer that works with the T class.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Create a TextWriter to hold the serialization.
            string serialization;
            using (TextWriter writer = new StringWriter())
            {
                // Serialize the object.
                serializer.Serialize(writer, obj);
                serialization = writer.ToString();
            }

            // Return the serialization.
            return serialization;
        }

        // Deserialize a serialization string.
        public static T Deserialize<T>(string serialization)
        {
            // Create a serializer that works with the T class.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // Create a reader from which to read the serialization.
            using (TextReader reader = new StringReader(serialization))
            {
                // Deserialize.
                T obj = (T)serializer.Deserialize(reader);

                // Return the object.
                return obj;
            }
        }
    }
}
