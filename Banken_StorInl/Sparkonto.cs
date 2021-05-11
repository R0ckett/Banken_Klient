using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class Sparkonto : Konto
    {
        double ränta;

        public Sparkonto(double saldo, double ränta) : base(saldo)
        {
            this.ränta = ränta;
        }
    }
}
