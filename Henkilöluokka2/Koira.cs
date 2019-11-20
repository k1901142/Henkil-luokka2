using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henkilöluokka2
{
    [Serializable]
    class Koira : Eläin
    {
        public Koira(string nimi)

        {
            nimi_ = nimi;
            sanoo_ = "HAU HAU";
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
