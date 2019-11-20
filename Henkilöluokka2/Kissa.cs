using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henkilöluokka2
{
    [Serializable]
    class Kissa : Eläin
    { 
        public Kissa(string nimi)
        {
            nimi_ = nimi;
            sanoo_ = "MIUA";
        }
        public override string sanoo()
        {
            string sanoo = nimi_ + " " + sanoo_;
            return sanoo;
        }
        public new string nuku()
        {
            string nuku = "zzzz";
            return nuku;
        }

    }
}
