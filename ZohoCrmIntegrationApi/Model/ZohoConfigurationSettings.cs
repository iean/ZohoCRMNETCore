using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZohoCrmIntegrationApi.Model
{
    public class ZohoConfigurationSettings
    {
        public string client_id { get; set; }
        public string redirect_uri { get; set; }
        public string client_secret { get; set; }
        public string access_type { get; set; }
        public string iamUrl { get; set; }
        public string persistence_handler_class { get; set; }
        public string mysql_username { get; set; }
        public string mysql_password { get; set; }
        public string mysql_database { get; set; }
        public string mysql_server { get; set; }
        public string mysql_port { get; set; }
        public string oauth_tokens_file_path { get; set; }
        public string apiBaseUrl { get; set; }
        public string photoUrl { get; set; }
        public string apiVersion { get; set; }
        public string logFilePath { get; set; }
        public string timeout { get; set; }
        public string minLogLevel { get; set; }
        public string domainSuffix { get; set; }
        public string currentUserEmail { get; set; }
        public string accountbaseurl { get; set; }

        public string refreshtoken { get; set; }

    }
}
