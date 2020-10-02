using System;
using System.Globalization;

namespace FON.IRC.Glyphs.ToFromString
{
    public class GlyphFromString
    {
        public GlyphData FromString(string glyph)
        {
            GlyphData glyphData = new GlyphData();
            string[] glyphs = glyph.Split(';');
            if (glyphs[0] != "")
            {
                glyphData.FormDefinitionKey = Guid.Parse(glyphs[0]);
            }
            if (glyphs[1] != "")
            {
                glyphData.CorrelationKey = Guid.Parse(glyphs[1]);
            }
            if (glyphs[2] != "")
            {
                glyphData.PageNumber = Int32.Parse(glyphs[2]);
            }
            return glyphData;
        }
    }
}
