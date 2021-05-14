using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class ISKkonto : Konto, IFormatString
    {
        int AntalAktier;
        
        public ISKkonto(double saldo, int AntalAktier) : base(saldo)
        {
            this.AntalAktier = AntalAktier;
        }
        public ISKkonto(string iskkontoString)
        {
            string[] arr = iskkontoString.Split(';');
            AntalAktier = int.Parse(arr[1]);
            saldo = double.Parse(arr[3]);
        }
        public override string Presentera()
        {
            return "saldo: " + saldo + " antal aktier: " + AntalAktier;
        }
        public override string FormateraString()
        {
            return "ISK(aktier) " + ";" + AntalAktier + ";" + "(Saldo): " + ";" +  base.FormateraString();
        }
        public override void GenereraFrånString(string input)
        {
            string[] arr = input.Split(';');
            AntalAktier = int.Parse(arr[1]);
            base.GenereraFrånString(arr[3]);
        }

    }
}
