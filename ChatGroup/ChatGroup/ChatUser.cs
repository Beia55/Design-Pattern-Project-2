using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGroup
{
    public class ChatUser: IUser
    {
        public int ID { get; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public Message message;
        
        public ChatUser(string name, UserType type)
        {
            this.ID = new Random().Next(1, 100);
            this.Name = name;
            this.Type = type;
            message = new Message();
        }

        public void ReceiveEnteranceNotification(string userName)
        {
            Console.WriteLine(this.Name + " was notified that " + this.message.ShowEnterenceMessage(userName));
        }

        public void ReceiveExitNotification(string userName)
        {
            Console.WriteLine(this.Name + " was notified that " + this.message.ShowExitMessage(userName));
        }

        public void ReceiveMessageNotification(string userName, string text)
        {
            Console.WriteLine(this.Name + " was notified that " + this.message.ShowSendMessage(userName, text));
        }
    }
}
