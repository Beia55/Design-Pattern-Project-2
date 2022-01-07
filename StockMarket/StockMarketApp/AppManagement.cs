using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    class AppManagement
    {
        private MarketAgency marketAgency = new MarketAgency();
        private UserObserver user;

        // These are some predefined users as example
        UserObserver beia = new Buyer("Beia", 375.35, CurrencyTypes.Stellar);
        UserObserver gabi = new Buyer("Gabi", 280.70, CurrencyTypes.Bitcoin);
        UserObserver deni = new Follower("Deni", CurrencyTypes.Ethereum);
        UserObserver timi = new Follower("Timi", CurrencyTypes.USDcoin);

        public AppManagement() { }

        private void InitializePredefinedExample()
        {
            this.beia.Subscribe(NotificationsType.CHANGE, marketAgency);
            this.deni.Subscribe(NotificationsType.ADD, marketAgency);
            this.gabi.Subscribe(NotificationsType.ADDandCHANGE, marketAgency);
            this.timi.Subscribe(NotificationsType.CHANGE, marketAgency);
        }

        private bool Continue()
        {
            Console.WriteLine("More actons ? Write y - from yes - or n - from no ");
            string response = Console.ReadLine();

            if (response == "y" || response == "yes" || response == "Y" || response == "Yes" || response == "YES")
            {
                return false;
            }
            else if (response == "n" || response == "no" || response == "N" || response == "No" || response == "NO")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Command doesn't exist ! Default = continue");
                return false;
            }
        }

        private void OperationsForUser(UserObserver user)
        {
            Console.WriteLine("\n Available options: \n" +
                "     Press 1 to subscribe for add notification only \n" +
                "     Press 2 to subscribe for change notification only \n" +
                "     Press 3 to subscribe for all notification \n" +
                "     Press 4 to unsubscribe from add notification only \n" +
                "     Press 5 to unsubscribe from change notification only \n" +
                "     Press 6 to unsubscribe from all notification \n");
            string option = Console.ReadLine();
            bool exit = false;
            
            while(exit == false)
            {
                switch (option)
                {
                    case "1":
                        user.Subscribe(NotificationsType.ADD, this.marketAgency);
                        exit = true;
                        break;
                    case "2":
                        user.Subscribe(NotificationsType.CHANGE, this.marketAgency);
                        exit = true;
                        break;
                    case "3":
                        user.Subscribe(NotificationsType.ADDandCHANGE, this.marketAgency);
                        exit = true;
                        break;
                    case "4":
                        user.Unsubscribe(NotificationsType.ADD, this.marketAgency);
                        exit = true;
                        break;
                    case "5":
                        user.Unsubscribe(NotificationsType.CHANGE, this.marketAgency);
                        exit = true;
                        break;
                    case "6":
                        user.Unsubscribe(NotificationsType.ADDandCHANGE, this.marketAgency);
                        exit = true;
                        break;
                    default:
                        exit = false;
                        Console.WriteLine("Command doesn't exist. Try Again");
                        break;
                }
            }
        }

        public void CreateCurrency(StockMarket stockMarket)
        {
            Console.WriteLine("\n Used Currencies: \n" +
                        "      " + stockMarket.ToString() +
                                         "  All options (Write the number for currency you want to use): \n" +
                        "      Write 1 for - " + CurrencyTypes.Bitcoin +
                        "      Write 2 for - " + CurrencyTypes.Cardano +
                        "      Write 3 for - " + CurrencyTypes.Chainlink +
                        "      Write 4 for - " + CurrencyTypes.Dogecoin +
                        "      Write 5 for - " + CurrencyTypes.Ethereum +
                        "      Write 6 for - " + CurrencyTypes.Polkadot +
                        "      Write 7 for - " + CurrencyTypes.Stellar +
                        "      Write 8 for - " + CurrencyTypes.Tether +
                        "      Write 9 for - " + CurrencyTypes.USDcoin +
                        "      Write 10 for - " + CurrencyTypes.XRP);
            string currencyType = Console.ReadLine();

            Console.WriteLine("\n Write the value for currency: \n");
            string currencyValue = Console.ReadLine();

            switch (currencyType)
            {
                case "1":
                    Currency a = new Currency(CurrencyTypes.Bitcoin, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(a, marketAgency);
                    break;
                case "2":
                    Currency b = new Currency(CurrencyTypes.Cardano, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(b, marketAgency);
                    break;
                case "3":
                    Currency c = new Currency(CurrencyTypes.Chainlink, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(c, marketAgency);
                    break;
                case "4":
                    Currency d = new Currency(CurrencyTypes.Dogecoin, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(d, marketAgency);
                    break;
                case "5":
                    Currency e = new Currency(CurrencyTypes.Ethereum, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(e, marketAgency);
                    break;
                case "6":
                    Currency f = new Currency(CurrencyTypes.Polkadot, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(f, marketAgency);
                    break;
                case "7":
                    Currency g = new Currency(CurrencyTypes.Stellar, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(g, marketAgency);
                    break;
                case "8":
                    Currency h = new Currency(CurrencyTypes.Tether, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(h, marketAgency);
                    break;
                case "9":
                    Currency i = new Currency(CurrencyTypes.USDcoin, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(i, marketAgency);
                    break;
                case "10":
                    Currency j = new Currency(CurrencyTypes.XRP, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(j, marketAgency);
                    break;
                default:
                    Currency k = new Currency(CurrencyTypes.Bitcoin, double.Parse(currencyValue));
                    stockMarket.AddNewCurrency(k, marketAgency);
                    Console.WriteLine("Command doesn't exist. Default = Bitcoin");
                    break;
            }
        }

        public void MakeActions()
        {
            this.InitializePredefinedExample();

            bool continueOption = false;

            while (continueOption == false)
            {

                Console.WriteLine("\n Available options: \n" +
                "     Press 1 to create user \n" +
                "     Press 2 to use an existing user \n" +
                "     Press 3 to make actions as StockManager \n");
            
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("\n Write the user name: \n");
                    string userName = Console.ReadLine();

                    Console.WriteLine("\n Position name: \n" +
                    "     Press 1 if you want to be a buyer \n" +
                    "     Press 2 if you want to be a follower \n");
                    string userType = Console.ReadLine();

                    if (userType == "1") { this.user = new Buyer(userName); }
                    else if (userType == "2") { this.user = new Follower(userName); }
                    else { Console.WriteLine("Command doesn't exist! Default = follower"); this.user = new Follower(userName); }

                    this.OperationsForUser(this.user);
                }
                else if (option == "2")
                {
                    Console.WriteLine("\n Choose the ID of an user from the list: \n");
                    Console.WriteLine(marketAgency.ToString());
                    string userID = Console.ReadLine();
                    marketAgency.GetUserByID(Int32.Parse(userID));

                    this.OperationsForUser(this.user);
                }
                else if (option == "3")
                {
                    StockMarket stockMarket = StockMarket.Instance;
                
                    Console.WriteLine("\n Administrative actions: \n" +
                        "     Press 1 if you want to add a new currency \n" +
                        "     Press 2 if you want to be modify an existing currency \n");
                    string administrativeOption = Console.ReadLine();

                    if (administrativeOption == "1")
                    {
                        this.CreateCurrency(stockMarket);
                    }
                    else if (administrativeOption == "2") {
                        Console.WriteLine("\n Choose a currency to modify: \n");
                        int i = 0;
                        foreach (Currency c in stockMarket._currencies)
                        {
                            i++;
                            Console.WriteLine("Press " +i + " for - " + c.Name + " with value - " + c.Value);
                        }
                        string readIndex = Console.ReadLine();
                        int currencyIndex = Int32.Parse(readIndex) - 1;
                        Currency currentSelectedCurrency = stockMarket._currencies[currencyIndex];

                        Console.WriteLine("\n Write the new value for the currency: \n");
                        string newValue = Console.ReadLine();

                        stockMarket.UpdateExistentCurrencyValue(currentSelectedCurrency.Name, double.Parse(newValue), marketAgency);
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist ! Defaul = add a new currency. ");

                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist !");
                }

                continueOption = this.Continue();
            }
        }
    }
}
