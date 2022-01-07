using System;

namespace StockMarketApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n");

            // --------------- DINAMICALLY EXAMPLE

            AppManagement appManagement = new AppManagement();
            appManagement.MakeActions();


            // --------------- HARD-CODED EXAMPLE

            /*MarketAgency marketAgency = new MarketAgency();

            UserObserver beia = new Buyer("Beia", 375.35, CurrencyTypes.Stellar);
            UserObserver gabi = new Buyer("Gabi", 280.70, CurrencyTypes.Bitcoin);
            UserObserver deni = new Follower("Deni", CurrencyTypes.Ethereum); 
            UserObserver timi = new Follower("Timi", CurrencyTypes.USDcoin);

            StockMarket stockMarket = StockMarket.Instance;

            beia.Subscribe(NotificationsType.CHANGE, marketAgency);
            deni.Subscribe(NotificationsType.ADD, marketAgency);

            beia.Subscribe(NotificationsType.ADDandCHANGE, marketAgency);
            beia.Subscribe(NotificationsType.ADD, marketAgency);
            beia.Subscribe(NotificationsType.ADD, marketAgency);

            Console.WriteLine("\n");
            stockMarket.AddNewCurrency(new Currency(CurrencyTypes.Stellar, 23.55), marketAgency);
            stockMarket.UpdateExistentCurrencyValue(CurrencyTypes.Bitcoin, 20.00, marketAgency);
            Console.WriteLine("\n");

            beia.Unsubscribe(NotificationsType.ADD, marketAgency);
            beia.Unsubscribe(NotificationsType.ADDandCHANGE, marketAgency);

            gabi.Subscribe(NotificationsType.ADDandCHANGE, marketAgency);
            timi.Subscribe(NotificationsType.CHANGE, marketAgency);

            Console.WriteLine("\n");
            stockMarket.UpdateExistentCurrencyValue(CurrencyTypes.Bitcoin, 20.00, marketAgency);
            stockMarket.AddNewCurrency(new Currency(CurrencyTypes.Cardano, 23.55), marketAgency);
            Console.WriteLine("\n");*/

        }
    }
}
