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
            return FormDefinitionKey + " " + PageNumber;
        }
    }
}
