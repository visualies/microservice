using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Entities
{
    public class MessagingConfig
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
