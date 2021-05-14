using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Konto : IFormatString
    {
        protected double saldo;
        public Konto()
        {
            this.saldo = 0;
        }
        public Konto(double saldo)
        {
            this.saldo = saldo;
        }
        public double Saldo
        {
            set { saldo = value; }
            get { return saldo; }
        }
        public Konto(string kontoRepresentationString)
        {
            saldo = double.Parse(kontoRepresentationString);
        }
        public void SkrivUtSaldo()
        {
            Console.WriteLine("Din nuvarande saldo är: " + saldo);
        }
         
        public virtual string Presentera()
        {
            return "saldo: " + saldo;
        }

        public virtual string FormateraString()
        {
            string returnString = "";
            returnString += saldo.ToString();
            return returnString;
        }
        public virtual void GenereraFrånString(string input)
        {
            saldo = double.Parse(input);
        }
    }
}
