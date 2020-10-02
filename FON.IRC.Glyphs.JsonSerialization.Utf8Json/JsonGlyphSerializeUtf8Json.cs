using System;
using Utf8Json;
using Utf8Json.Resolvers;

namespace FON.IRC.Glyphs.JsonSerialization.Utf8Json
{
    public class JsonGlyphSerializeUtf8Json
    {

        public string Serialize(GlyphData glyphData)
        {
            //CompositeResolver.RegisterAndSetAsDefault(new IJsonFormatter[] { new GlyphDataFormatter() }, new[] { StandardResolver.Default});
            return JsonSerializer.ToJsonString(glyphData);

        }

        public GlyphData Deserialize(string json)
        {
            //CompositeResolver.RegisterAndSetAsDefault(new IJsonFormatter[] { new GlyphDataFormatter() }, new[] { StandardResolver.Default });
            return JsonSerializer.Deserialize<GlyphData>(json);
        }
    }
}
