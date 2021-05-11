using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    class ISKkonto : Konto
    {
        int AntalAktier;
        
        public ISKkonto(double saldo, int AntalAktier) : base(saldo)
        {
            this.AntalAktier = AntalAktier;
        }

    }
}
