using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Henkilöluokka2
{
    [Serializable]
    class Henkilö  :Eläin
    {
        private new string nimi_;
        private int syntymäpäivä_;
        private int syntymäkuukausi_;
        private int syntymävuosi_;
        private DateTime syntymaaika_;


        public string lempinimi_
        {
            get
            {
                return lempinimi_;
            }
            set
            {
                lempinimi_ = value;
            }
        }


        public Henkilö(string nimi, int späivä, int skuukausi, int svuosi)   //Konstruktori jossa syntymäpäivän tiedot kysytään useammalla rivillä
        {
       
            nimi_ = nimi;
            if (späivä > 31 || späivä < 1) //päivä ei ole mahdollinen
            {
                syntymäpäivä_ = 1;
            }
            else
            {
                syntymäpäivä_ = späivä;
            }
            if (skuukausi > 12 || skuukausi < 1)   //kuukausi ei ole mahdollinen
            {
                syntymäkuukausi_ = 1;
            }
            else
            {
                syntymäkuukausi_ = skuukausi;
            }

            syntymävuosi_ = svuosi;

            syntymaaika_ = new DateTime(Convert.ToInt32(syntymävuosi_), Convert.ToInt32(syntymäkuukausi_), Convert.ToInt32(syntymäpäivä_));

            sanoo_ = "Minun nimeni on "+nimi_;   //Ihminen esittelee itsensä
        }
        public Henkilö(string nimi, string syntynyt)    //Konstruktori jossa syntymäpäivä ilmoitetaan yhdellä rivillä
        {
            nimi_ = nimi;


            string[] tiedot = syntynyt.Split('.');
            int paiva = Convert.ToInt32(tiedot[0]);
            int kuukausi = Convert.ToInt32(tiedot[1]);
            int vuosi = Convert.ToInt32(tiedot[2]);

            syntymaaika_ = new DateTime(vuosi, kuukausi, paiva);

            sanoo_ = "Minun nimeni on " + nimi_;  //Ihminen esittelee itsensä
        }

        public void muuttaaSanoa(string sanoo)
        {
            sanoo_ = sanoo;
        }
        public void puhuu()
        {
            Console.WriteLine(sanoo_);
        }
        public override string sanoo()      
        {
            string sanoo = sanoo_;
            return sanoo;      
        }
        public DateTime Syntymäpäivä()
        {
            return syntymaaika_;
        }


        public new String  Nimi()
        {
            return nimi_.ToString();
        }
        public string Ika()
        {
            bool pelkkaVuosi = false;
            string ika = LaskeIka(pelkkaVuosi);   //funktio palauttaa täyden iän
            return ika;
            
        }
        public new string nuku()
        {
            bool pelkkaVuosi = true;
            string tmp = LaskeIka(pelkkaVuosi);  //funktio palauttaa vain iän vuosina
            int vuodet = Convert.ToInt32(tmp);

            if(vuodet > 60)  //Vanhus kuorsaa
            {
                return "kuorsausta";
            }
            else if(vuodet < 3)  //Lapsi itkee
            {
                return "itkua";
            }
            else
            {
                return "zzzz";
            }

        }
        private string LaskeIka(bool pelkkaVuosi)   //Selvittää henkilön iän. Parametri ilmoittaa halutaanko vain vuosissa vai tarkasti
        {
            int tVuosi = int.Parse(DateTime.Now.Year.ToString());
            int tkuukausi = int.Parse(DateTime.Now.Month.ToString());
            int tpäivä = int.Parse(DateTime.Now.Day.ToString());

            int ikaV = 0;
            int ikaKK = 0;
            int ikaPV = 0;

            syntymäpäivä_ = syntymaaika_.Day;
            syntymäkuukausi_ = syntymaaika_.Month;
            syntymävuosi_ = syntymaaika_.Year;

            if (tkuukausi > syntymäkuukausi_)    //tämän vuoden synttäri vietetty
            {
                ikaV = tVuosi - syntymävuosi_;
            }
            else if (tkuukausi == syntymäkuukausi_) //tämän vuoden synttärit tässä kuussa
            {
                if (tpäivä > syntymäpäivä_)  //synttärit olleet
                {
                    ikaV = tVuosi - syntymävuosi_;
                }
                else if (tpäivä == syntymäpäivä_)  //synttäri tänään
                {
                    ikaV = tVuosi - syntymävuosi_;
                }
                else                              //synttärit ihan kohta
                {
                    ikaV = tVuosi - syntymävuosi_ - 1;


                }
            }
            else                         //synttärit myöhemmin
            {
                ikaV = tVuosi - syntymävuosi_ - 1;
            }

            if (syntymäpäivä_ > tpäivä)      //syntymäpäivä ei vielä ohitettu tässä kuussa
            {
                ikaKK = -1;
            }


            ikaKK = ikaKK + tkuukausi - syntymäkuukausi_;   //jos alle 0 lainataan edelliseltä vuodelta 12kk
            if (ikaKK < 0)
            {
                ikaKK = ikaKK + 12;
            }

            ikaPV = tpäivä - syntymäpäivä_;   //Jos alle 0 lainataan edelliseltä kuukaudelta 30
            if (ikaPV < 0)
            {
                ikaPV = ikaPV + 30;
            }

            if (pelkkaVuosi)  //Jos halutaan vain ikä vuosissa
            {
                return ikaV.ToString(); 
            }
            else  // Palautetaan tarkka ikä
            {
                return ikaV + " vuotta " + ikaKK + " kuukautta ja " + ikaPV + " päivää vanha.";
            }
        }

    }
}
