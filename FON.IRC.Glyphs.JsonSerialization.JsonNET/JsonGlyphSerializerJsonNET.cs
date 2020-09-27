using Newtonsoft.Json;
using System;
using System.IO;

namespace FON.IRC.Glyphs.JsonSerialization
{
    public class JsonGlyphSerializerJsonNET
    {
        public string Serialize(GlyphData glyphData)
        {
            return JsonConvert.SerializeObject(glyphData);
        }
        public string Serialize1(GlyphData glyphData)
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);


            writer.WriteStartObject();

            if (glyphData.FormDefinitionKey.HasValue)
            {
                writer.WritePropertyName("FormDefinitionKey");
                writer.WriteValue(glyphData.FormDefinitionKey);
            }

            if (glyphData.CorrelationKey.HasValue)
            {
                writer.WritePropertyName("CorrelationKey");
                writer.WriteValue(glyphData.CorrelationKey);
            }

            writer.WritePropertyName("PageNumber");
            writer.WriteValue(glyphData.PageNumber);

            writer.WriteEndObject();

            return sw.ToString();
        }
        public GlyphData Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<GlyphData>(json);
        }
        public GlyphData Deserialize1(string json)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(json));

            GlyphData glyphData = new GlyphData();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    switch (reader.Value)
                    {
                        case nameof(GlyphData.FormDefinitionKey):
                            {
                                var value = reader.ReadAsString();
                                if (value != null)
                                    glyphData.FormDefinitionKey = Guid.Parse(value);

                                break;
                            }
                        case nameof(GlyphData.CorrelationKey):
                            {
                                var value = reader.ReadAsString();
                                if (value != null)
                                    glyphData.CorrelationKey = Guid.Parse(value);
                                break;
                            }
                        case nameof(GlyphData.PageNumber):
                            {
                                var value = reader.ReadAsInt32();
                                if (value.HasValue)
                                    glyphData.PageNumber = value.Value;
                                break;
                            }
                    }
                }
            }

            return glyphData;
        }


    }
}
