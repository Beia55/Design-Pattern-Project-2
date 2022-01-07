using System;

namespace ChatGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*ChatServer server1 = new ChatServer("try-me");
            IUser ana = new ChatUser("Ana", UserType.ActivUser);
            IUser ion = new ChatUser("Ion", UserType.ActivUser);
            IUser emi = new ChatUser("Emi", UserType.ObserverUser);
            IUser tommy = new ChatUser("Tommy", UserType.ObserverUser);
            IUser lara = new ChatUser("Lara", UserType.ObserverUser);

            server1.RegisterUser((ChatUser)ion);
            server1.RegisterUser((ChatUser)emi);
            server1.RegisterUser((ChatUser)ion);
            server1.RegisterUser((ChatUser)ana);
            server1.UnregisterUser((ChatUser)ion);

            server1.SendMessage((ChatUser)ion, "Some text");
            server1.SendMessage((ChatUser)ana, "Hello, team !");

            server1.RegisterUser((ChatUser)tommy);
            server1.RegisterUser((ChatUser)lara);

            server1.SendMessage((ChatUser)emi, "I'm just an observer");*/

            GroupManagement groupManagement = new GroupManagement();
            groupManagement.makeActions();
        }
    }
}
