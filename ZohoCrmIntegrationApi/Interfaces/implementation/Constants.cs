using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZohoCrmIntegrationApi.Interfaces.implementation
{
    public class ZohoConstants
    {
        #region Zoho Configuration PROPERTY NAMES
        public static string CLIENT_ID = "client_id";
        public static string CLIENT_SECRET = "client_secret";
        public static string REDIRECT_URI = "redirect_uri";
        public static string ACCESS_TYPE = "access_type";
        public static string IAM_URL = "iamUrl" ;
        public static string PRESISTENCE_HANDLER_CLASS = "persistence_handler_class";
        public static string MYSQL_USERNAME = "mysql_username";
        public static string MYSQL_PASSWORD = "mysql_password";
        public static string MYSQL_DATABASE = "mysql_database";
        public static string MYSQL_SERVER = "mysql_server";
        public static string MYSQL_PORT = "mysql_port";
        public static string AUTH_TOKEN_FILE_PATH = "oauth_tokens_file_path";
        public static string API_BASE_URL = "apiBaseUrl";
        public static string PHOTO_URL = "photoUrl";
        public static string API_VERSION = "apiVersion";
        public static string LOG_FILE_PATH = "logFilePath";
        public static string TIMEOUT = "timeout";
        public static string MIN_LOG_LEVEL = "minLogLevel";
        public static string DOMAIN_SUFFIX = "domainSuffix";
        public static string CURRENT_USER_EMAIL = "currentUserEmail";
        #endregion


        #region Module Strings

        public static string LEAD_MODULE_STRING = "Leads";
        #endregion
    }
}
