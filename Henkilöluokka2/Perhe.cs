using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Henkilöluokka2
{
    [Serializable]
    class Perhe
    {
        private Henkilö aiti_;
        private Henkilö isa_;
        private List<Henkilö> lapset_ = new List<Henkilö>();
        private Eläin lemmikki_;

        public Perhe(Henkilö aiti, Henkilö isa)  //Perheessä on aina isä ja äiti
        {
            aiti_ = aiti;
            isa_ = isa;
        }
        public void lisaaLapsi(Henkilö lapsi)   //Lisätään lapsi
        {
            lapset_.Add(lapsi);
        }
        public Henkilö vanhinLapsi()   //Palauttaa vanhimman lapsen tiedot
        {
            if (lapset_.Count != 0)  //onko edes lapsia
            {

                Henkilö testi = new Henkilö("Testi", DateTime.Today.Date.ToString("dd/MM/yyyy"));
                foreach (Henkilö tyyppi in lapset_)
                {
                    if (tyyppi.Syntymäpäivä() < testi.Syntymäpäivä())
                    {
                        testi = tyyppi;
                    }

                }
                return testi;
            }
            Console.WriteLine("Perheessä ei ole lapsia.");
            return null;


        }
        public void perheenTiedot()     //Tulostaa perheen tiedot
        {
            Console.WriteLine("Perheen äiti on " + aiti_.Nimi() + ". Hän on " + aiti_.Ika());
            Console.WriteLine("Perheen isä on " + isa_.Nimi() + ". Hän on " + isa_.Ika());

            int moneskoLapsi = 0;
            bool onkoLapsia = false;
            foreach (Henkilö lapsi in lapset_)  //Jos on lapsia
            {
                moneskoLapsi++;
                Console.WriteLine("Lapsi " + moneskoLapsi + " on " + lapsi.Nimi() + " joka on " + lapsi.Ika());
                onkoLapsia = true;
            }
            if (!onkoLapsia)
            {
                Console.WriteLine("Perheessä ei ole lapsia.");
            }
                
            if(lemmikki_ is Koira)
            {
                Console.WriteLine("Koira "+ lemmikki_.sanoo());
            }
            if(lemmikki_ is Kissa)
            {
                Console.WriteLine("Kissa " + lemmikki_.sanoo());

            }
                   
        }
        public void lisaaLemmikki(Eläin lemmikki)
        {
            lemmikki_ = lemmikki;  
        }
        public void onkoLemmikkia()
        {
            if(lemmikki_ == null)
            {
                Console.WriteLine("Perheellä ei ole lemmikkiä");
            }
            else
            {
               Console.WriteLine(lemmikki_.sanoo());
            }
        }
        public override string ToString()    //Perheen tiedot toString() muunnoksella
        {
            string palautusArvo;
            palautusArvo = "Äiti " + aiti_.Nimi() + "\nIsä " + isa_.Nimi();

            int counter = 0;
            foreach (Henkilö lapsi in lapset_)
            {
                counter++;
                palautusArvo += "\nLapsi " + counter + ":" + lapsi.Nimi();
            }

            if(lemmikki_!= null)
            {
                if (lemmikki_ is Koira)
                {
                    palautusArvo += "\nKoira: " + lemmikki_.sanoo();
                }
                else if(lemmikki_ is Kissa)
                {
                    palautusArvo += "\nKissa: " + lemmikki_.sanoo();
                }
            }
            return palautusArvo;
        }


 


     

    }
}
