using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRCSample.Entities
{
    public class ChatUsers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string EMail { get; set; }
    }
}
