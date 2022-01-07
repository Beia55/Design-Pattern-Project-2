using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGroup
{
    public interface IUser
    {
        void ReceiveMessageNotification(string userName, string text);
        void ReceiveEnteranceNotification(string userName);
        void ReceiveExitNotification(string userName);
    }
}
