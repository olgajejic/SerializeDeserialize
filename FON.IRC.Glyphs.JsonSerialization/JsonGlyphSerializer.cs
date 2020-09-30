using System;
using System.Buffers;
using System.IO;
using System.Text;
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

        public string Serialize1(GlyphData glyphData)
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);

            writer.WriteStartObject();

            if (glyphData.FormDefinitionKey.HasValue)
            {
                writer.WriteString("FormDefinitionKey", glyphData.FormDefinitionKey.ToString());
            }

            if (glyphData.CorrelationKey.HasValue)
            {
                writer.WriteString("CorrelationKey", glyphData.CorrelationKey.ToString());
            }

            writer.WriteNumber("PageNumber", glyphData.PageNumber);

            writer.WriteEndObject();
            writer.Flush();
            return Encoding.UTF8.GetString(ms.ToArray());

        }

        public GlyphData Deserialize1(string json)
        {
            Utf8JsonReader reader = new Utf8JsonReader(Encoding.ASCII.GetBytes(json));

            GlyphData glyphData = null;

            while (reader.Read())
            {

                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        glyphData = new GlyphData();
                        break;
                    case JsonTokenType.PropertyName:
                        {
                            var value = reader.GetString();

                            reader.Read();
                            if (value.Equals("FormDefinitionKey"))
                            {
                                var s = reader.GetString();
                                if (s != null)
                                    glyphData.FormDefinitionKey = Guid.Parse(s);

                            }
                            else if (value.Equals("CorrelationKey"))
                            {
                                var v = reader.GetString();
                                if (v != null)
                                    glyphData.CorrelationKey = Guid.Parse(v);
                            }
                            else if (value.Equals("PageNumber"))
                            {
                                glyphData.PageNumber = reader.GetInt32();
                            }
                            break;
                        }
                    case JsonTokenType.EndObject:
                        return glyphData;
                }

            }
            return glyphData;

        }

    }
}
