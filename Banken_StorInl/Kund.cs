using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Kund : IFormatString
    {
        string namn;
        long personNummer;
        List<Konto> konton = new List<Konto>();
        public Kund(string namn, long personNummer)
        {
            this.namn = namn;
            this.personNummer = personNummer;
        }
        public Kund(string namn, long personNummer, List<Konto> konton)
        {
            this.namn = namn;
            this.personNummer = personNummer;
            this.konton = konton;
        }
        public Kund(string kundRepresentationString)
        {
            string[] arr = kundRepresentationString.Split('#');
            namn = arr[1];
            personNummer = long.Parse(arr[3]);
            konton.Rensa();

            for (int i = 5; i < arr.Length; i++)
            {
                Konto k;
                string kontostring = arr[i];
                if (kontostring.Substring(0, 9) == "Sparkonto")
                {
                    k = new Sparkonto(kontostring);
                }
                else
                {
                    k = new ISKkonto(kontostring);
                }
                konton.LäggTill(k);
            }
        }
        public List<Konto> Konton
        {
            get { return konton; }
        }
        public string Namn
        {
            get { return namn; }
        }
        public long PersonNummer
        {
            get { return personNummer; }
        }
        public void LäggTillKonto(Konto k)
        {
            konton.LäggTill(k);
        }
        public void TaBortKonto(int idx)
        {
            konton.TaBortVid(idx-1);
        }
        public string PresenteraKonton()
        {
            string allaKonton = "";
            
            for (int i = 0; i < konton.Count; i++)
            {              
                string num = (i+1).ToString();
                allaKonton += "[" + num + "]: " + konton.FåVärde(i).Saldo + "\n";
            }
            return "Namn: " + namn + "\nPersonnummer: " + personNummer + "\nKonton:\n" + allaKonton;
        }
        public string FormateraString()
        {
            string returnString = "";
            returnString += "namn: " + "#" + namn.ToString()+ "#" + "Personnummer: " +"#"+ personNummer.ToString()+ "#" + "Konton: ";

            for (int i = 0; i < konton.Count; i++)
            {
                returnString += "#" + konton.FåVärde(i).FormateraString();
            }
            return returnString;
        }
        public void GenereraFrånString(string input)
        {
            string[] arr = input.Split('#');
            namn = arr[1];
            personNummer = long.Parse(arr[3]);
            konton.Rensa();
            for (int i = 5; i < arr.Length; i++)
            {
                Konto k = new Konto(0);
                k.GenereraFrånString(arr[i]);
                konton.LäggTill(k);
            }

        }
    }
}
