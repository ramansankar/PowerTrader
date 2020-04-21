using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Interface
{
    public interface IIndicator
    {
        
        void Calculate();
        bool CheckParameters();


    }
}
