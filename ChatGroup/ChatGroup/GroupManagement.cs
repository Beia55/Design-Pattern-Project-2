using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGroup
{
    public class GroupManagement
    {
        private List<ChatServer> _servers = new List<ChatServer>();

        public GroupManagement()
        {
            _servers.Add(new ChatServer("Intro-group-1"));
            _servers.Add(new ChatServer("Intro-group-2"));
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

        public void DisplayGroups()
        {
            foreach(ChatServer serv in _servers)
            {
                Console.WriteLine(" ===> Chat Group = " + serv.GroupName + ", ID = " + serv.GroupID + ". Members: \n" +
                    serv.DisplayUsers());
            }
        }

        public void makeActions()
        {
            bool continueOption = false;

            while (continueOption == false)
            {
                Console.WriteLine("\n Do you want to create a group or to join a group ? \n" +
                "     Press 1 to create one \n" +
                "     Press 2 to join one \n" +
                "     Press 3 to  make action into a group - default \n");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("\n Name your group: ");
                    string groupName = Console.ReadLine();
                    ChatServer server = new ChatServer(groupName);
                    _servers.Add(server);

                    this.DisplayGroups();
                    continueOption = this.Continue();
                }
                else if (option == "2")
                {
                    Console.WriteLine("\n Write the group ID you want to join in. The option are: ");
                    foreach (ChatServer server in _servers)
                    {
                        Console.WriteLine(" ---> Group ID = " + server.GroupID + ". Group Name = " + server.GroupName);
                    }
                    string groupID = Console.ReadLine();

                    Console.WriteLine("\n Write your name");
                    string userName = Console.ReadLine();

                    Console.WriteLine("\n Choose type: \n" +
                        "     Press 1 to be an observer user \n" +
                        "     Press 2 to be an active user - default \n");
                    string userType = Console.ReadLine();

                    if (userType == "1")
                    {
                        IUser user = new ChatUser(userName, UserType.ObserverUser);
                        foreach (ChatServer serv in _servers)
                        {
                            if (Int32.Parse(groupID) == serv.GroupID)
                            {
                                serv.RegisterUser((ChatUser)user);
                            }
                        }
                    }
                    else if (userType == "2")
                    {
                        IUser user = new ChatUser(userName, UserType.ActivUser);
                        foreach (ChatServer serv in _servers)
                        {
                            if (Int32.Parse(groupID) == serv.GroupID)
                            {
                                serv.RegisterUser((ChatUser)user);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command !");
                    }

                    this.DisplayGroups();
                    continueOption = this.Continue();
                }
                else if (option == "3")
                {
                    Console.WriteLine("\n Write the group ID you want to make actions. The option are: ");
                    foreach (ChatServer server in _servers)
                    {
                        Console.WriteLine(" ---> Group ID = " + server.GroupID + ". Group Name = " + server.GroupName);
                    }
                    string groupID = Console.ReadLine();

                    Console.WriteLine("\n Choose action you want to make: \n" +
                        "     Press 1 remove users from group \n" +
                        "     Press 2 to sent message - default \n");
                    string chooseAction = Console.ReadLine();

                    if (chooseAction == "1")
                    {
                        foreach (ChatServer serv in _servers)
                        {
                            if (Int32.Parse(groupID) == serv.GroupID)
                            {
                                Console.WriteLine("Write the user Id who you want to remove from group :");

                                foreach (ChatUser user in serv._users)
                                {
                                    Console.WriteLine("- " + user.Name + " with ID = " + user.ID);
                                }

                                string userIDToRemove = Console.ReadLine();
                                foreach (ChatUser user in serv._users)
                                {
                                    if (user.ID == Int32.Parse(userIDToRemove))
                                    {
                                        serv.UnregisterUser(user);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID !");
                                    }
                                }
                            }
                        }
                    }
                    else if (chooseAction == "2")
                    {
                        foreach (ChatServer serv in _servers)
                        {
                            if (Int32.Parse(groupID) == serv.GroupID)
                            {
                                Console.WriteLine("Chat Group Members:");
                                foreach (ChatUser user in serv._users)
                                {
                                    Console.WriteLine("- " + user.Name + " with ID = " + user.ID);
                                }
                                Console.WriteLine("Who send the message? - ");
                                string senderID = Console.ReadLine();
                                Console.WriteLine("Which is the message ?");
                                string senderMessage = Console.ReadLine();
                                foreach (ChatUser user in serv._users)
                                {
                                    if (user.ID == Int32.Parse(senderID))
                                    {
                                        serv.SendMessage(user, senderMessage);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID !");
                                    }
                                }
                            }
                        }

                        continueOption = this.Continue();
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist !");
                        this.Continue();

                    }

                }
            }
        }
    }
}
