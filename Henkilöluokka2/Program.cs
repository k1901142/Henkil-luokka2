using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Henkilöluokka2
{
    class Program
    {
        static void Main(string[] args)
        {
          
            {
              
                Talonyhtiö asunnot = new Talonyhtiö();
                int valittu = 0;

                asunnot.lataa();    //ladataan Talonyhtiön perheet tiedostosta
                while (true)
                    {
                    
                    //Tulostetaan valikko
                    Console.WriteLine("1. Laske henkilön ikä?");
                    Console.WriteLine("2. Lisää perhe");
                    Console.WriteLine("3. Perheiden tiedot");
                    Console.WriteLine("4. Tallenna perheet");
                    Console.WriteLine("5. Tyhjennä perheet");
                    Console.WriteLine("9. Sammuta");

                    //Selvitetään mitä tehdään
                    Console.WriteLine("Anna mitä haluat tehdä?");
                    valittu = Convert.ToInt16(Console.ReadLine());

          
                    switch (valittu)
                    {
                        case 1:
                            henkilonTiedot();         //Kysyy nimen ja syntymäpäivän, ilmoittaa iän

                            break;
                        case 2:
                            luoPerhe(asunnot);        // Luo perheen taloyhtiöön

                            break;
                        case 3:
                            perheidenTiedot(asunnot);  //Tulostaa taloyhtiön perheet
                            break;
                        case 4:
                            asunnot.Tallenna();       //Tallentaa perheiden tiedot tiedostoon
                            break;
                        case 5:
                            asunnot.perheet.Clear();       //Tyhjentää taloyhtiön
                            break;
                        case 9:
                            break;              // Sammutetaan ohjelma
                          
                        default:                //Virheellinen valinta, tulostetaan valikko uudestaan
                            Console.WriteLine("Virheellinen valinta");
                            break;
                    }
                    Console.WriteLine();
                    if(valittu ==9)             //Tallennetaanko taloyhtiö ohjelman sulkeutuessa
                    {
                        Console.WriteLine("Tallennetaanko perheet? k/e");
                        string vastaus = Console.ReadLine();
                        if(vastaus.ToUpper()=="K")
                        {
                            asunnot.Tallenna();
                        }
                        

                        break;
                    }
                   
                }
                
               
            }


            void kirjoitetaanPerheTiedostoon(Perhe tallenetaan)       //tiedostoon tallennus (ei käytetä)
            {
                File.WriteAllText("tiedosto.txt", tallenetaan.ToString());

            }
            void luetaanTiedostosta()           //tiedostosta luku (ei käytetä)
            {

                List<string> tekstiä = new List<string>(File.ReadLines("tiedosto.txt"));
                foreach(string rivi in tekstiä)
                {
                    Console.WriteLine(rivi);
                }
         /*      string[] lines = File.ReadAllLines("tiedosto.txt");
                List<string> tekstiä = new List<string>();
                for(int i = 0; i < lines.Count();i++)
                {
                   tekstiä.Add(lines[i]);
               }
    */        }


            void kirjoitetaanHenkioTiedostoon(Henkilö tallenetaan)       //tiedostoon tallennus (ei käytetä)
            {
                File.WriteAllText("tiedosto.txt", tallenetaan.Nimi()+" "+ tallenetaan.Syntymäpäivä());


            }
            void luetaanTiedostostaHenkio()           //tiedostosta luku (ei käytetä)
            {
                string nimi = " ";
                string syntymäpäivä = " ";

                List<string> tekstiä = new List<string>(File.ReadLines("tiedosto.txt"));
                foreach (string rivi in tekstiä)
                {

                    string[] parsittu = rivi.Split(' ', '.');

                    nimi = parsittu[0];
                    syntymäpäivä = parsittu[1] + "." + parsittu[2] + "." + parsittu[3];

                }

                Henkilö ladattava = new Henkilö(nimi, syntymäpäivä);

                Console.WriteLine("Nimi {0} Syntynyt {1} \nHän on {2}", ladattava.Nimi(), ladattava.Syntymäpäivä().ToString("dd.MM.yyyy"), ladattava.Ika());
                Console.WriteLine();

            }




            void henkilonTiedot()     //Tulostaa iän syntymäpäivän perusteella
            {
                Console.WriteLine("Anna henkilön nimi?");
                string nimi = Console.ReadLine();
                Console.WriteLine("Anna syntymäpäiväsi (pp.kk.vvvv)");
                string späivä = Console.ReadLine();

                Henkilö mina = new Henkilö(nimi, späivä);

              Console.WriteLine("Nimi {0} Syntynyt {1} \nHän on {2}", mina.Nimi(), mina.Syntymäpäivä().ToString("dd.MM.yyyy"), mina.Ika());
              Console.WriteLine();

         
            }

            void luoPerhe(Talonyhtiö asunnot)   //Luo uuden perheen taloyhtiöön
            {
                Console.WriteLine("Lisää perhe");

                Console.WriteLine("Montako lasta?");        //Lasten määrä
                int lastenMaara = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Anna äidin nimi?");   //Äidin tiedot
                string nimi_äiti = Console.ReadLine();
                Console.WriteLine("Anna syntymäpäivä  (pp.kk.vvvv)");
                string späivää_äiti = Console.ReadLine();

                Henkilö äiti = new Henkilö(nimi_äiti, späivää_äiti);

                Console.WriteLine("Anna isän nimi?");    //Isän tiedot
                string nimi_isä = Console.ReadLine();
                Console.WriteLine("Anna syntymäpäivä  (pp.kk.vvvv)");
                string späivää_isä = Console.ReadLine();


                Henkilö isä = new Henkilö(nimi_isä, späivää_isä);

                Perhe perhe = new Perhe(äiti, isä);

                asunnot.lisaaPerhe(perhe);

                for (int i = 0; i < lastenMaara; i++)   //Lasten määrä vaihtelee, kysytään tiedot
                {
                    Console.WriteLine("Anna lapsen {0} nimi?", (i + 1));        
                    string nimi = Console.ReadLine();
                    Console.WriteLine("Anna lapsen {0} syntymäpäivä", (i + 1));
                    string späivä = Console.ReadLine();

                    asunnot.perheet[asunnot.perheet.Count()-1].lisaaLapsi(new Henkilö(nimi, späivä));
                    
                    
                }
                Console.WriteLine("Onko lemmikkiä k/e");  //Lemmikin tiedot
                if (Console.ReadLine().ToUpper() == "K")
                {
                    Console.WriteLine("Kissa vai koira?");
                    string laji = Console.ReadLine();
                    if (laji.ToUpper() == "KISSA")
                    {
                        Console.WriteLine("Anna kissan nimi");
                        string nimi = Console.ReadLine();
                        asunnot.perheet[asunnot.perheet.Count() - 1].lisaaLemmikki(new Kissa(nimi));
                    }
                    if (laji.ToUpper() == "KOIRA")
                    {
                        Console.WriteLine("Anna koiran nimi");
                        string nimi = Console.ReadLine();
                        asunnot.perheet[asunnot.perheet.Count() - 1].lisaaLemmikki(new Koira(nimi));
                    }
                }

               

            }
            void perheidenTiedot(Talonyhtiö asunnot)    //Tulostetaan taloyhtiön perheiden tiedot
            {
                for (int i = 0; i < asunnot.perheet.Count(); i++)
                {
                    asunnot.perheet[i].perheenTiedot();
                    Console.WriteLine("");
                }
               
            }
        }
    }
}
