using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FON.IRC.Glyphs.JsonSerialization
{
    public class JsonGlyphSerializer
    {
        public string Serialize(GlyphData glyphData)
        {
          return JsonSerializer.Serialize(glyphData);
        }

        public GlyphData Deserialize(string json)
        {
           return JsonSerializer.Deserialize<GlyphData>(json);
        }
    }
}
