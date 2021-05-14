using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Konto : IFormatString
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
