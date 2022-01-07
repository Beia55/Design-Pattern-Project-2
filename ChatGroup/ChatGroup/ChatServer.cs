using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGroup
{
    public class ChatServer : IChatServer
    {
        public List<IUser> _users;
        public string GroupName { get; set; }
        public int GroupID { get; set; }

        public ChatServer(string name)
        {
            this.GroupID = new Random().Next(1, 100);
            this.GroupName = name;
            _users = new List<IUser>();
        }

        public void RegisterUser(ChatUser user)
        {
            if(_users.Count() < 10)
            {
                if (_users.Contains(user))
                {
                    Console.WriteLine(user.Name + " is already in group !");
                } else {
                    int countObserverType = 0;
                    foreach(ChatUser u in _users)
                    {
                        if(u.Type == UserType.ObserverUser)
                        {
                            countObserverType++;
                        }
                    }

                    if (user.Type == UserType.ObserverUser && countObserverType >= 2)
                    {
                        Console.WriteLine("Only 2 observer are allowed in this group ! Please register as an active user !");
                    } else {
                        foreach (ChatUser u in _users)
                        {
                            if (u.Name != user.Name)
                            {
                                u.ReceiveEnteranceNotification(user.Name);
                            }
                        }
                        this._users.Add(user);
                    }
                }
            }
        }

        public void UnregisterUser(ChatUser user)
        {
            foreach (ChatUser u in _users)
            {
                if (u.Name != user.Name)
                {
                    u.ReceiveExitNotification(user.Name);
                }
            }
            this._users.Remove(user);
        }

        public void SendMessage(ChatUser user, string message)
        {
            if (_users.Contains(user))
            {
                if(user.Type == UserType.ActivUser)
                {
                    foreach(ChatUser u in _users)
                    {
                        if(u.Name != user.Name)
                        {
                            u.ReceiveMessageNotification(user.Name, message); 
                        }
                    }
                } else
                {
                    Console.WriteLine("Sorry, you are observer. If you want to send messages, update your type to active user !");
                }
            } else
            {
                Console.WriteLine(user.Name + " is not part of this group !");
            }
        }

        public string DisplayUsers()
        {
            string response = "";
            int i = 0;
            foreach (ChatUser u in _users)
            {
                response += "- User Name = " + u.Name + ". User Type = " + u.Type + ". User ID = " + u.ID + "\n";
                i++;
            }
            if(i == 0)
            {
                response = "No members";
            }
            return response;
        }
    }
}
