using System;
using Utf8Json;

namespace FON.IRC.Glyphs.JsonSerialization.Utf8Json
{
    public class JsonGlyphSerializeUtf8Json
    {

        public string Serialize(GlyphData glyphData)
        {
            return JsonSerializer.ToJsonString(glyphData);

        }

        public GlyphData Deserialize(string json)
        {
            return JsonSerializer.Deserialize<GlyphData>(json);
        }
    }
}
