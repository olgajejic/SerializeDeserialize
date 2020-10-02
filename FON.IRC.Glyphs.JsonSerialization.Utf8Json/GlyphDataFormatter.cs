using System;
using System.Collections.Generic;
using System.Text;
using Utf8Json;

namespace FON.IRC.Glyphs.JsonSerialization.Utf8Json
{
    public sealed class GlyphDataFormatter : IJsonFormatter<GlyphData>
    {
        public GlyphData Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
                return null;

            GlyphData glyphData = new GlyphData();
            var count = 0;
            while (reader.ReadIsInObject(ref count))
            {
                switch (reader.GetCurrentJsonToken())
                {
                    case JsonToken.String:
                        var s = reader.ReadPropertyName();

                        if (s.Equals("FormDefinitionKey"))
                        {
                            var value = reader.ReadString();
                            if (value != null)
                            {
                                glyphData.FormDefinitionKey = Guid.Parse(value);
                            }
                        }

                        else if (s.Equals("CorrelationKey"))
                        {
                            var ss = reader.ReadString();
                            if (ss != null)
                            {
                                glyphData.CorrelationKey = Guid.Parse(ss);
                            }
                        }
                        else if (s.Equals("PageNumber"))

                        {
                            glyphData.PageNumber = reader.ReadInt32();
                        }
                        break;
                    default:
                        break;
                }
            }
            return glyphData;
        }

        public void Serialize(ref JsonWriter writer, GlyphData value, IJsonFormatterResolver formatterResolver)
        {
            writer.WriteBeginObject();

            if (value.FormDefinitionKey.HasValue)
            {
                writer.WritePropertyName("FormDefinitionKey");
                formatterResolver.GetFormatter<Guid>().Serialize(ref writer, value.FormDefinitionKey.Value, formatterResolver);
                writer.WriteValueSeparator();
            }
            if (value.CorrelationKey.HasValue)
            {
                writer.WritePropertyName("CorrelationKey");
                formatterResolver.GetFormatter<Guid>().Serialize(ref writer, value.CorrelationKey.Value, formatterResolver);
                writer.WriteValueSeparator();
            }
            if (value.PageNumber != -1)
            {
                writer.WritePropertyName("PageNumber");
                formatterResolver.GetFormatter<int>().Serialize(ref writer, value.PageNumber, formatterResolver);
            }

            writer.WriteEndObject();
        }
    }
}
