using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public class Currency
    {
        public CurrencyTypes Name { get; set; }
        public double Value{ get; set; }

        public Currency(CurrencyTypes name, double value)
        { 
            this.Name = name;
            this.Value= value;
        }

        public override string ToString()
        {
            return "Name = "+ this.Name +" and value = " + this.Value;
        }
    }
}
