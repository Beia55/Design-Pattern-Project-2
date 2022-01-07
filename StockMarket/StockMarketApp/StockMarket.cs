using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public enum NotificationsType{ ADD, CHANGE, ADDandCHANGE, NONE }

    public class StockMarket
    {
        private static readonly object _lockObject = new object();
        private static StockMarket _logger;// = new LoggerSingleton();
        private static int _counter = 0;

        public List<Currency> _currencies = new List<Currency> {
                new Currency(CurrencyTypes.Bitcoin, 12.31),
                /*new Currency(CurrencyTypes.Cardano, 11.44),*/
                new Currency(CurrencyTypes.Chainlink, 13.65),  
                new Currency(CurrencyTypes.Dogecoin, 10.07),  
                new Currency(CurrencyTypes.Ethereum, 14.78),  
                /*new Currency(CurrencyTypes.Polkadot, 9.49),*/
                /*new Currency(CurrencyTypes.Stellar, 15.00),*/
                /*new Currency(CurrencyTypes.Tether, 12.03), */ 
                new Currency(CurrencyTypes.USDcoin, 13.54),  
                new Currency(CurrencyTypes.XRP, 11.86),  
        };

        public NotificationsType ActionType { get; set; }

        private StockMarket()
        {
            ActionType = NotificationsType.NONE;
        }

        public static StockMarket Instance
        {
            get
            {
                if (_logger == null)
                {
                    lock (_lockObject)
                    {
                        if (_logger == null)
                        {
                            _logger = new StockMarket();
                            _counter++;
                        }
                    }
                }

                return _logger;
            }
        }

        public void AddNewCurrency(Currency currency, MarketAgency marketAgency = null)
        {
            this.ActionType = NotificationsType.ADD;

            if (_currencies.Contains(currency))
            {
                Console.WriteLine("This currency already exist !");
            }
            else
            {
                int exist = 0;
                foreach(Currency currentCurrecy in _currencies)
                {
                    if(currentCurrecy.Name == currency.Name)
                    {
                        exist = 1;
                        break;
                    }
                    else
                    {
                        exist = 0;
                    }
                }

                if (exist == 0)
                {
                    _currencies.Add(currency);
                    if (marketAgency != null)
                    {
                        marketAgency.NotifyOnNewCurrency(currency);
                    }
                }
                else
                {
                    Console.WriteLine("This {0} currency already exist !", currency.Name);
                }

            }
        }

        public void UpdateExistentCurrencyValue(CurrencyTypes currencyName, double newValue, MarketAgency marketAgency = null)
        {
            this.ActionType = NotificationsType.CHANGE;
            foreach (Currency currentCurrency in _currencies)
            {
                if (currentCurrency.Name == currencyName)
                {
                    currentCurrency.Value = newValue;
                    if (marketAgency != null)
                    {
                        marketAgency.NotifyOnChangeCurrency(currencyName, newValue);
                    }
                } 
            }
        }

        public override string ToString()
        {
            string currenciesList = "";
            foreach (Currency currency in _currencies)
            {
                currenciesList += currency.ToString() + "\n";
            }
            return currenciesList;
        }
    }
}
