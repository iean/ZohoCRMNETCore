using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZohoCrmIntegrationApi.Model;

namespace ZohoCrmIntegrationApi.Interfaces
{
    public interface IConfigurationService
    {
        Dictionary<string, string> GetZohoConfiguration();
        string GetGrandToken();
        ZohoConfigurationSettings getSettings();
        void InitializeZoho(Dictionary<string, string> configuration);
    }
}
