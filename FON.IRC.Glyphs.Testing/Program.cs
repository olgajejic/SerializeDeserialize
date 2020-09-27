using BenchmarkDotNet.Running;
using FON.IRC.Glyphs.JsonSerialization;
using FON.IRC.Glyphs.JsonSerialization.Utf8Json;
using System;



namespace FON.IRC.Glyphs.Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarking>();

            //GlyphData glyphData = new GlyphData() { FormDefinitionKey = Guid.NewGuid(), PageNumber = 1 };

            //var json = new JsonGlyphSerializer().Serialize(glyphData);
            //var gd = new JsonGlyphSerializeUtf8Json().Deserialize(json);

            //Console.WriteLine($"result: {json}");
            //Console.WriteLine(gd);
            //Console.ReadLine();
        }
    }
}

