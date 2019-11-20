using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Henkilöluokka2
{
    [Serializable]
    public class Eläin : IElävä
    {
        protected string sanoo_;
        protected string nimi_;

        public bool nisäkäs
        {
            get
            {
                return nisäkäs;
            }
            set
            {
               
                
               nisäkäs = value;
                
            }
        }

       

        public virtual string sanoo()
        {
            return nimi_+" "+sanoo_;
        }
        public string Nimi()
        {
            return nimi_;
        }
        public string nuku()
        {
            return "zzzz";
        }
        public string hengitä()
        {
            return "hengitystä";
        }

    }
}