using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public class Follower: UserObserver
    {
        public CurrencyTypes InterestedInType { get; set; }

        public Follower(string name): base(name) { }

        public Follower(string name, CurrencyTypes interestedInType)
            : base(name)
        {
            this.InterestedInType = interestedInType;
        }
    }
}
