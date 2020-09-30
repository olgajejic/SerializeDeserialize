using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FON.IRC.Glyphs.JsonSerialization
{
    public class CustomJsonGlyphSerializer : JsonConverter<GlyphData>
    {
        string json;
        public override GlyphData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, GlyphData glyphData, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (glyphData.FormDefinitionKey.HasValue)
            {
                writer.WritePropertyName("FormDefinitionKey");
                writer.WriteStringValue((Guid)glyphData.FormDefinitionKey);
            }

            if (glyphData.CorrelationKey.HasValue)
            {
                writer.WritePropertyName("CorrelationKey");
                writer.WriteStringValue((Guid)glyphData.CorrelationKey);
            }

            writer.WritePropertyName("PageNumber");
            writer.WriteNumberValue(glyphData.PageNumber);

            writer.WriteEndObject();
            json = writer.ToString();
        }
    }
}
