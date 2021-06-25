using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Entities
{
    public class DataConfig
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public int Port { get; set; }

        public string GetConnectionString()
        {
            return $"Server={Host}; Database={Database}; User Id={User}; Password={Password}; Port={Port};";
        }
    }
}
