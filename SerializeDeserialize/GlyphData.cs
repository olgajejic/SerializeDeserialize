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
        public GlyphData(Guid? fd, Guid? ck, int pn)
        {
            this.Fd = fd;
            this.Ck = ck;
            this.Pn = pn;
        }
        public Guid? Fd { get; set; }
        public Guid? Ck { get; set; }
        public int Pn { get; set; }

        public override string ToString()
        {
            return Fd + " " + Pn;
        }
    }
}
