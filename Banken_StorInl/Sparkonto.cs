using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Sparkonto : Konto, IFormatString
    {
        double ränta;

        public Sparkonto(double saldo, double ränta) : base(saldo)
        {
            this.ränta = ränta;
        }
        public Sparkonto(string sparkontoString)
        {
            string[] arr = sparkontoString.Split(';');
            ränta = int.Parse(arr[1]);
            saldo = double.Parse(arr[3]);
        }
        public override string Presentera()
        {
            return "saldo: " + saldo + " ränta: " + ränta + "%";
        }
        public override string FormateraString()
        {
            return "Sparkonto (ränta): " + ";" + ränta + ";" + "(Saldo): " + ";" + base.FormateraString();
        }
        public override void GenereraFrånString(string input)
        {
            string[] arr = input.Split(';');
            ränta = int.Parse(arr[1]);
            base.GenereraFrånString(arr[3]);
        }
    }
}
