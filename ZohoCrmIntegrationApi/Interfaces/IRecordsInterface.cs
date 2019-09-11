using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.CRUD;

namespace ZohoCrmIntegrationApi.Interfaces
{
    public interface IRecordsInterface
    {
        List<ZCRMRecord> GetAllRecords(string crmModuleName);
        ZCRMRecord GetSpecificRecord(string crmModuleName, long recordId);
        List<ZCRMField> GetFields(string crmModuleName);
    }
}
