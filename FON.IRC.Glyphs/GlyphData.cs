using System;

namespace FON.IRC.Glyphs
{
    public class GlyphData
    {

        public GlyphData()
        {

        }
        public GlyphData(Guid? fd, Guid? ck, int pn)
        {
            this.FormDefinitionKey = fd;
            this.CorrelationKey = ck;
            this.PageNumber = pn;
        }
        public Guid? FormDefinitionKey { get; set; }
        public Guid? CorrelationKey { get; set; }
        public int PageNumber { get; set; }

        public override string ToString()
        {
            return FormDefinitionKey + ";" + CorrelationKey + ";" + PageNumber;
        }
        public static GlyphData FromString(string glyph)
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
