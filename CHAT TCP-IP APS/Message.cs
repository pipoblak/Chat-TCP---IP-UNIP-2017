using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_TCP_IP_APS
{
    public class Message
    {
        public static int CONNECTED_TYPE = 0;
        public static int SIMPLE_MESSAGE_TYPE = 1;
        public static int MESSAGE_PM_TYPE = 2;
        public static int DISCONNECTED_TYPE = 3;
        public static int REFRESH_TYPE = 4;
        public static int PING_TYPE = 5;
        public static int REFRESH_PING_TYPE = 6;

        public UserClient from { get; set; }
        public UserClient to { get; set; }
        public string message { get; set; }
        public int msgType { get; set; }

        public string strMessage(UserClient from, UserClient to, string message, int msgType)
        {
            this.from = from;
            this.to = to;
            this.message = message;
            this.msgType = msgType;
            return getSerializedMessage();
        }

        public string getSerializedMessage() {
            string str = JsonConvert.SerializeObject(this);
            return str;

        }
        public static Message getDeserializedMessage(string text)
        {
           return JsonConvert.DeserializeObject<Message>(text);

        }

    }
    
}
