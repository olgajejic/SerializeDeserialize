using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeDeserialize
{
    public class GlyphData
    {

        public GlyphData()
        {

        }
        public GlyphData(string? fd, string? ck, int pn)
        {
            this.Fd = fd;
            this.Ck = ck;
            this.pn = pn;
        }
        public string? Fd { get; set; }
        public string? Ck { get; set; }
        public int pn { get; set; }

        public override string ToString()
        {
            return  Fd + " " + pn;
        }
    }
}
