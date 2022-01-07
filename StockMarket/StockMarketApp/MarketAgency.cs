using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketApp
{
    public class MarketAgency
    {
        private List<UserObserver> _observers;
        public StockMarket _stock = StockMarket.Instance;

        public MarketAgency()
        {
            this._observers = new List<UserObserver>();
        }

        public void Subscribe(UserObserver observer, NotificationsType type)
        {
            if (!_observers.Contains(observer))
            {
                observer._NotificationsType = type;
                _observers.Add(observer);
                Console.WriteLine("{0} succesfully subscribed to {1} notification", observer.Name, observer._NotificationsType);
            } else if (_observers.Contains(observer))
            {
                foreach(UserObserver obs in _observers)
                {
                    if(observer.UniqueIdentifier == obs.UniqueIdentifier)
                    {
                        if (obs._NotificationsType == NotificationsType.ADD && (type == NotificationsType.CHANGE || type == NotificationsType.ADDandCHANGE)) 
                        {
                            obs._NotificationsType = NotificationsType.ADDandCHANGE;
                            observer._NotificationsType = NotificationsType.ADDandCHANGE;
                            Console.WriteLine("{0} succesfully subscribed to {1} notification", observer.Name, observer._NotificationsType);
                        }
                        else if (obs._NotificationsType == NotificationsType.CHANGE && type == NotificationsType.ADD || type == NotificationsType.ADDandCHANGE)
                        {
                            obs._NotificationsType = NotificationsType.ADDandCHANGE;
                            observer._NotificationsType = NotificationsType.ADDandCHANGE;
                            Console.WriteLine("{0} succesfully subscribed to {1} notification", observer.Name, observer._NotificationsType);
                        }
                        else if(obs._NotificationsType == NotificationsType.ADDandCHANGE){
                            observer._NotificationsType = NotificationsType.ADDandCHANGE;
                            Console.WriteLine("You are already subscribed to all notifications");
                        } else
                        {
                            Console.WriteLine("Unknown error ! Impossible to subscribe.");
                        }
                    } 
                }
            }
        }

        public void Unsubscribe(UserObserver observer, NotificationsType type)
        {
            if (_observers.Contains(observer))
            {
                foreach (UserObserver obs in _observers)
                {
                    if (observer.UniqueIdentifier == obs.UniqueIdentifier)
                    {
                        if ((obs._NotificationsType == NotificationsType.ADDandCHANGE && type == NotificationsType.ADDandCHANGE) || (obs._NotificationsType == NotificationsType.ADD && type == NotificationsType.ADD) || (obs._NotificationsType == NotificationsType.CHANGE && type == NotificationsType.CHANGE))
                        {
                            _observers.Remove(obs);
                            Console.WriteLine("{0} succesfully unsubscribed from {1} notification. You are not subscribed to notification anymore !", observer.Name, type);
                            break;
                        }
                        else if (obs._NotificationsType == NotificationsType.ADDandCHANGE && type == NotificationsType.ADD)
                        {
                            obs._NotificationsType = NotificationsType.CHANGE;
                            observer._NotificationsType = NotificationsType.CHANGE;
                            Console.WriteLine("{0} succesfully unsubscribed from {1} notification. Now, you are subscribed to {2} notifications.", observer.Name, type, obs._NotificationsType);
                        }
                        else if (obs._NotificationsType == NotificationsType.ADDandCHANGE && type == NotificationsType.CHANGE)
                        {
                            obs._NotificationsType = NotificationsType.ADD;
                            observer._NotificationsType = NotificationsType.ADD;
                            Console.WriteLine("{0} succesfully unsubscribed from {1} notification. Now, you are subscribed to {2} notifications.", observer.Name, type, obs._NotificationsType);
                        }  else if ((obs._NotificationsType == NotificationsType.ADD && type == NotificationsType.CHANGE) || (obs._NotificationsType == NotificationsType.CHANGE && type == NotificationsType.ADD))
                        {
                            Console.WriteLine("You're not subscribed to this kind of notification ! Imposible to unsubscribe ");
                        } else if ((obs._NotificationsType == NotificationsType.ADD && type == NotificationsType.ADDandCHANGE) || (obs._NotificationsType == NotificationsType.CHANGE && type == NotificationsType.ADDandCHANGE))
                        {
                            _observers.Remove(obs);
                            Console.WriteLine("{0} succesfully unsubscribed from {1} notification. You are not subscribed to notification anymore !", observer.Name, type);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Unknown error ! Impossible to unsubscribe.");
                        }
                    }
                }
            } else
            {
                Console.WriteLine("You are not subscribed !");
            }
        }

        public void NotifyOnNewCurrency(Currency currency)
        {
            if (_stock.ActionType == NotificationsType.ADD)
            {
                foreach (var obs in _observers)
                {
                    if(obs._NotificationsType == NotificationsType.ADD || obs._NotificationsType == NotificationsType.ADDandCHANGE)
                    {
                        obs.NotifyMeOnAdds(currency);
                    }
                }
            } else
            {
                Console.WriteLine("Not exist new added !");
            }
        }

        public void NotifyOnChangeCurrency(CurrencyTypes currencyName, double newValue)
        {
            if (_stock.ActionType == NotificationsType.CHANGE)
            {
                foreach (var observer in _observers)
                {
                    if(observer._NotificationsType == NotificationsType.CHANGE || observer._NotificationsType == NotificationsType.ADDandCHANGE)
                    {
                        observer.NotifyMeOnChanges(currencyName, newValue);
                    }
                }
            } else
            {
                Console.WriteLine("Not exist new changes !");
            }
        }

        public UserObserver GetUserByID(int id)
        {
            UserObserver currentUser = null;
            foreach(UserObserver user in _observers)
            {
                if(user.UniqueIdentifier == id)
                {
                    currentUser = user;
                }
            }
            return currentUser;
        }

        public override string ToString()
        {
            string usersList = "";
            foreach(UserObserver user in _observers)
            {
                usersList += user.ToString() + "\n";
            }
            return usersList;
        }

    }
}
