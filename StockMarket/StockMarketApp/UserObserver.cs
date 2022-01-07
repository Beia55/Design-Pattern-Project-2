using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public abstract class UserObserver { 
        
        public int UniqueIdentifier { get; set; }
        public string Name { get; set; }

        public NotificationsType _NotificationsType { get; set; }

        public UserObserver(string name)
        {
            this.Name = name;
            this.UniqueIdentifier = new Random().Next(1, 1000);
        }

        public void Subscribe(NotificationsType type, MarketAgency marketAgency)
        {
            marketAgency.Subscribe(this, type);
        }

        public void Unsubscribe(NotificationsType type, MarketAgency marketAgency)
        {
            marketAgency.Unsubscribe(this , type);
        }

        public void NotifyMeOnAdds(Currency currency)
        {
            Console.WriteLine("{0} was notified that it was added a new currency: {1}", this.Name, currency.ToString());
        }

        public void NotifyMeOnChanges(CurrencyTypes currencyName, double newValue)
        {
            Console.WriteLine("{0} was notified that the value for {1} Currency was changed in {2}", this.Name, currencyName, newValue);
        }

        public override string ToString()
        {
            return "User "+this.Name+ " has the unique identifier: "+this.UniqueIdentifier+" and notification type: "+this._NotificationsType;
        }
    }
}
