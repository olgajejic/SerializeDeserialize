using BenchmarkDotNet.Running;
using FON.IRC.Glyphs.JsonSerialization;
using FON.IRC.Glyphs.JsonSerialization.Utf8Json;
using FON.IRC.Glyphs.ToFromString;
using System;
using System.Text.Json;

namespace FON.IRC.Glyphs.Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarking>();

           // var a = new Benchmarking();
           // a.Setup();
           //// a.DeserializeUtf8JsonDefault();
           // a.DeserializeUtf8JsonCustom();

            //GlyphData glyphData = new GlyphData() { FormDefinitionKey = Guid.NewGuid(), PageNumber = 1 };
            //// Console.WriteLine(glyphData.ToString());
        
            //Console.WriteLine(GlyphData.FromString(glyphData.ToString()));
            ////var json = new JsonGlyphSerializeUtf8Json().Serialize(glyphData);

            ////var gd = JsonGlyphSerializeUtf8Json.Deserialize(json);

            ////    Console.WriteLine($"result: {json}");


            ////    ////Console.WriteLine(gd.CorrelationKey);
            ////    ////Console.WriteLine(gd.PageNumber);
            ////Console.WriteLine("Objekat: " + gd);
            //Console.ReadLine();
        }
    }
}


