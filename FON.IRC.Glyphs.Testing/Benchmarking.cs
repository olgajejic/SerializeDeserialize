using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using FON.IRC.Glyphs.JsonSerialization;
using FON.IRC.Glyphs.JsonSerialization.Utf8Json;
using FON.IRC.Glyphs.ToFromString;
using System;
using System.Collections.Generic;
using System.Text;
using Utf8Json;
using Utf8Json.Resolvers;

namespace FON.IRC.Glyphs.Testing
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class Benchmarking
    {
        private GlyphData _glyphSource;
        private string _jsonSource;

        [GlobalSetup]
        public void Setup()
        {
            CompositeResolver.RegisterAndSetAsDefault(new IJsonFormatter[] { new GlyphDataFormatter() }, new[] { StandardResolver.Default });
            _glyphSource = new GlyphData() { FormDefinitionKey = Guid.NewGuid(), PageNumber = 1 };
            _jsonSource = (new JsonGlyphSerializer()).Serialize(_glyphSource);
        }

        [BenchmarkCategory("Serialization"), Benchmark]
        public void SerializeDotNetDefault()
        {
            var json = (new JsonGlyphSerializer()).Serialize(_glyphSource);
        }
        [BenchmarkCategory("Serialization"), Benchmark]
        public void SerializeDotNetCustom()
        {
            var json = (new JsonGlyphSerializer()).Serialize1(_glyphSource);
        }
        [BenchmarkCategory("Serialization"), Benchmark]
        public void SerializeJsonNETDefault()
        {
            var json = (new JsonGlyphSerializerJsonNET()).Serialize(_glyphSource);
        }

        [BenchmarkCategory("Serialization"), Benchmark(Baseline = true)]
        public void SerializeJsonNETCustom()
        {
            var json = (new JsonGlyphSerializerJsonNET()).Serialize1(_glyphSource);
        }

        [BenchmarkCategory("Serialization"), Benchmark]
        public void SerializeUtf8JsonDefault()
        {
            var json = (new JsonGlyphSerializeUtf8Json()).Serialize(_glyphSource);
        }
        [BenchmarkCategory("Serialization"), Benchmark]
        public void SerializeUtf8JsonCustom()
        {
            var json = (new JsonGlyphSerializeUtf8Json()).Serialize(_glyphSource);
        }
        [BenchmarkCategory("ToString"), Benchmark]
        public void GlyphDataToString()
        {
            var json = (new GlyphData()).ToString();
        }
        [BenchmarkCategory("Deserialization"), Benchmark]
        public void DeserializeDotNetDefault()
        {
            var glyph = (new JsonGlyphSerializer()).Deserialize(_jsonSource);
        }
        [BenchmarkCategory("Deserialization"), Benchmark]
        public void DeserializeDotNetCustom()
        {
            var glyph = (new JsonGlyphSerializer()).Deserialize1(_jsonSource);
        }
        [BenchmarkCategory("Deserialization"), Benchmark]
        public void DeserializeJsonNETDefault()
        {
            var glyph = (new JsonGlyphSerializerJsonNET()).Deserialize(_jsonSource);
        }

        [BenchmarkCategory("Deserialization"), Benchmark(Baseline = true)]
        public void DeserializeJsonNETCustom()
        {
            var glyph = (new JsonGlyphSerializerJsonNET()).Deserialize1(_jsonSource);
        }

        [BenchmarkCategory("Deserialization"), Benchmark]
        public void DeserializeUtf8JsonDefault()
        {
            var glyph = (new JsonGlyphSerializeUtf8Json()).Deserialize(_jsonSource);
        }
        [BenchmarkCategory("Deserialization"), Benchmark]
        public void DeserializeUtf8JsonCustom()
        {
            var glyph = (new JsonGlyphSerializeUtf8Json()).Deserialize(_jsonSource);
        }
        [BenchmarkCategory("ToString"), Benchmark]
        public void GlyphDataFromString()
        {
            var json = (new GlyphFromString()).FromString((new GlyphData()).ToString());
        }

    }
}
