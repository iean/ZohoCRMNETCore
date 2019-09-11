using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.Setup.RestClient;
using ZCRMSDK.OAuth.Client;
using ZCRMSDK.OAuth.Contract;
using ZohoCrmIntegrationApi.Model;

namespace ZohoCrmIntegrationApi.Interfaces.implementation
{
    public class ZohoConfiguration : IConfigurationService
    {
        ZohoConfigurationSettings _settings;
        public ZohoConfiguration(Microsoft.Extensions.Options.IOptions<Model.ZohoConfigurationSettings> settings)
        {
               this._settings = settings.Value;
        }

        public string GetGrandToken()
        {
            try
            {
                var client = new RestClient(this._settings.accountbaseurl);
                var request = new RestRequest("oauth/v2/auth", Method.GET);
                request.AddUrlSegment("scope", "ZohoCRM.users.ALL");
                request.AddUrlSegment("client_id", this._settings.client_id);
                request.AddUrlSegment("response_type", "code");
                request.AddUrlSegment("access_type", this._settings.access_type);
                request.AddUrlSegment("redirect_uri", _settings.redirect_uri);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public ZohoConfigurationSettings getSettings()
        {
            return this._settings;
        }

        public Dictionary<string, string> GetZohoConfiguration()
        {
            var config = new Dictionary<string, string>();
            if (this._settings != null)
            {
                foreach (var property in this._settings.GetType().GetProperties())
                {

                    if (property.GetValue(this._settings) != null)
                    {
                        config.Add(property.Name, property.GetValue(this._settings).ToString());
                    }
                }
            }

            return config;
        }

        public void InitializeZoho(Dictionary<string, string> configuration)
        {
            ZCRMRestClient.Initialize(configuration);

            #region authorizing zoho
            ZohoOAuthClient client = ZohoOAuthClient.GetInstance();
            string refreshToken = this._settings.refreshtoken;
            ZohoOAuthTokens tokens = client.GenerateAccessTokenFromRefreshToken(refreshToken, this._settings.currentUserEmail);
            #endregion 
        }

    }
}
