using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGroup
{
    public class Message
    {
        public string ShowEnterenceMessage(string userName)
        {
            return userName + " arrived in the group ";
        }

        public string ShowExitMessage(string userName)
        {
            return userName + " left the group ";
        }

        public string ShowSendMessage(string sender , string text)
        {
            return sender + " send the message: " + text;
        }
    }
}
