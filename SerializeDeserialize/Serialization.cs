using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerializeDeserialize
{
   public class Serialization
    {
        List<GlyphData> data;
        private readonly Random _random = new Random();
        public Serialization()
        {
            data = new List<GlyphData>();
            createData();
            string json = Serialize();
            Deserialize(json);
        }

        public void createData()
        {
            for (int i = 0; i < 1000; i++)
            {
                data.Add(new GlyphData(RandomString(RandomNumber(50, 156)), null, RandomNumber(1,1000000)));
            }
        }

        public string Serialize()
        {
            string filePath = @"C:\Users\snezanaj\source\repos\glyphData.json";

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = (TypeNameAssemblyFormatHandling)System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };
            string json = JsonConvert.SerializeObject(data, settings);
            
            File.WriteAllText(filePath, json);
         
            return json;
        }

        public void Deserialize(string json)
        {
            string filePath = @"C:\Users\snezanaj\source\repos\glyphData.json";
            if (File.Exists(filePath) == false)
                throw new Exception($"File doesn't exist on given path: '{filePath}'");
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, 
            };
           
            var data = JsonConvert.DeserializeObject<List<GlyphData>>(json, settings);

            foreach (var e in data)
            {
                Console.WriteLine(e);
            }
            Console.Read();
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
