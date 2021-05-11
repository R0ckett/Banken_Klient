using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Konto
    {
        double saldo;
        
        public Konto(double saldo)
        {
            this.saldo = saldo;
        }
        public double Saldo
        {
            set { saldo = value; }
            get { return saldo; }
        }
        public void SkrivUtSaldo()
        {
            Console.WriteLine("Din nuvarande saldo är: " + saldo);
        }

    }
}
