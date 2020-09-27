using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerializeDeserialize
{
    public class Benchamark
    {
        private string source;

        public void Setup()
        {
            source = Serialize2(createData1());
        }
        public GlyphData createData1()
        {
            return new GlyphData(null, new Guid(), 123456789);
        }

        public string Serialize2(GlyphData gd)
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);


            writer.WriteStartObject(); //writes the beggining of json object

            if (gd.FormDefinitionKey != null)
            {
                writer.WritePropertyName("fd");
                writer.WriteValue(gd.FormDefinitionKey);
            }

            if (gd.CorrelationKey != null)
            {
                writer.WritePropertyName("ck");
                writer.WriteValue(gd.CorrelationKey);
            }

            writer.WritePropertyName("pn");
            writer.WriteValue(gd.PageNumber);

            writer.WriteEndObject();

            return sw.ToString();
        }


        [Benchmark]
        public void Deserialize2()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(source));
            reader.Read();
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
        [Benchmark]
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
    }
}
