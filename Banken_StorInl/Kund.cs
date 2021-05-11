using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Kund
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
            return "Konton:\n" + allaKonton;
        }
        public string Presentera()
        {
            string allaKonton = "";
            for (int i = 0; i < konton.Count; i++)
            {
                allaKonton += "[" + (i+1) + "]: " + konton.FåVärde(i) + "\n";
            }
            return "Namn: " + namn + "\nPersonnummer: " + personNummer + "\nKonton:\n" + allaKonton; 
        }
    }
}
