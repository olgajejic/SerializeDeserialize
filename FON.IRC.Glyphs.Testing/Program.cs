using BenchmarkDotNet.Running;
using FON.IRC.Glyphs.JsonSerialization;
using FON.IRC.Glyphs.JsonSerialization.Utf8Json;
using System;
using System.Text.Json;

namespace FON.IRC.Glyphs.Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarking>();

            //var a = new Benchmarking();
            //a.Setup();
            //a.DeserializeDotNetCustom();
            //GlyphData glyphData = new GlyphData() { FormDefinitionKey = Guid.NewGuid(), PageNumber = 1 };
            //JsonGlyphSerializer jsonGlyphSerializer = new JsonGlyphSerializer();
            //var json = jsonGlyphSerializer.Serialize1(glyphData);
            ////    var options = new JsonSerializerOptions();
            ////    options.Converters.Add(new JsonGlyphSerializer());

            //// Console.WriteLine(glyphData.FormDefinitionKey);

            //GlyphData gd = jsonGlyphSerializer.Deserialize1(json);
            ////    string json = JsonSerializer.Serialize(glyphData, options);
            ////    //var gd = new JsonGlyphSerializeUtf8Json().Deserialize(json);

            //Console.WriteLine($"AAAAAAAAAA result: {json}");


            ////Console.WriteLine(gd.CorrelationKey);
            ////Console.WriteLine(gd.PageNumber);
            //Console.WriteLine(gd);
            //Console.ReadLine();
        }
    }
}


