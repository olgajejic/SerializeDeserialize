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
            //data = new List<GlyphData>();

            var before = DateTime.Now;

            string json = Serialize2(createData1());
            Deserialize2(json);

            Console.WriteLine(DateTime.Now - before);
            Console.ReadLine();
        }

        public GlyphData createData1()
        {
            return new GlyphData(null, new Guid(), RandomNumber(1, 1000000));
            //for (int i = 0; i < 1000; i++)
            //{
            //    data.Add(new GlyphData(RandomString(RandomNumber(50, 156)), null, RandomNumber(1,1000000)));
            //}
        }

        public string Serialize2(GlyphData gd)
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);


            writer.WriteStartObject(); //writes the beggining of json object

            if (gd.Fd != null)
            {
                writer.WritePropertyName("fd");
                writer.WriteValue(gd.Fd);
            }

            if (gd.Ck != null)
            {
                writer.WritePropertyName("ck");
                writer.WriteValue(gd.Ck);
            }

            writer.WritePropertyName("pn");
            writer.WriteValue(gd.Pn);

            writer.WriteEndObject();

            return sw.ToString();
        }

        public void Deserialize2(string json)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                //if (reader.Value != null)
                //{
                //Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                Console.WriteLine(reader.Value);
                //}
                //else
                //{
                //    Console.WriteLine("Token: {0}", reader.TokenType);
                //}
            }

        }

        public string Serialize1(GlyphData gd)
        {
            string filePath = @"C:\Users\snezanaj\source\repos\glyphData.json";

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = (TypeNameAssemblyFormatHandling)System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };
            string json = JsonConvert.SerializeObject(gd, settings);

            File.WriteAllText(filePath, json);

            return json;


        }

        public void Deserialize1(string json)
        {
            string filePath = @"C:\Users\snezanaj\source\repos\glyphData.json";
            if (File.Exists(filePath) == false)
                throw new Exception($"File doesn't exist on given path: '{filePath}'");
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            };

            //var data = JsonConvert.DeserializeObject<List<GlyphData>>(json, settings);
            var data = JsonConvert.DeserializeObject<GlyphData>(json, settings);

            Console.WriteLine(data);
            //foreach (var e in data)
            //{
            //    Console.WriteLine(e);
            //}
            // Console.ReadLine();
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
