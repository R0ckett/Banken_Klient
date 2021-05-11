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
