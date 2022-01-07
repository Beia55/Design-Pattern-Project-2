using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public class Buyer : UserObserver
    {
        public double PersonalAmount { get; set; }
        public CurrencyTypes PersonalAmountType { get; set; }

        public Buyer(string name) : base(name) { }

        public Buyer(string name, double personalAmount, CurrencyTypes personalAmountType)
            : base(name)
        {
            this.PersonalAmount = personalAmount;
            this.PersonalAmountType = personalAmountType;
        }
    }
}
