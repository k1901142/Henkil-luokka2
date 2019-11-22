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
    class Talonyhtiö
    {
        public List<Perhe> perheet;

        public Talonyhtiö()
        {
            perheet = new List<Perhe>();
        }
        public Talonyhtiö(List<Perhe> asukkaat)     //Lisätään uusi perhe taloyhtiöön
        {
            perheet = asukkaat;
        }


        public void lisaaPerhe(Perhe asukkaat)   //Konstruktorissa syötetään perheet taloyhtiöön
        {
            perheet.Add(asukkaat);
        }
        public int asuntoja()  //asuntojen (perheiden) lukumäärä
        {
            return perheet.Count;
        }

        public void Tallenna()  //Tallentaa perheet tiedostoon
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Perhe.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this.perheet);
            stream.Close();

        }
        public void lataa()      //Lataa perheet tiedostosta
        {
        
                IFormatter formatter = new BinaryFormatter();
            if (File.Exists("Perhe.txt")
                {
                Stream stream = new FileStream("Perhe.txt", FileMode.Open, FileAccess.Read);
                try
                {
                    perheet = (List<Perhe>)formatter.Deserialize(stream);
                }
                catch
                {

                }
                stream.Close();
            }
            
        }

        
    }
}
