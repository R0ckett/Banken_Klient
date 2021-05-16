using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken_StorInl
{
    interface IFormatString
    {
        //interface för att metoder som fyller objektets data från en string och metoder som formaterar objekts data till en string.
        void GenereraFrånString(string input);
        string FormateraString();
    }
}
