using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.Common;
using ZCRMSDK.CRM.Library.CRUD;

namespace ZohoCrmIntegrationApi.Interfaces.implementation
{
    public class ZohoRecordsService : IRecordsInterface
    {
        public List<ZCRMRecord> GetAllRecords(string crmModuleName)
        {

            try
            {
                ZCRMModule moduleIns = ZCRMModule.GetInstance(crmModuleName); //module api name
                List<string> fields = new List<string> { "Last_Name", "Company", "Email", "id" }; //field api name
                BulkAPIResponse<ZCRMRecord> response = moduleIns.GetRecords(fields);// get Records with cvId, sortByField, sortOrder, startIndex, endIndex and fieldApiNamelist.
                List<ZCRMRecord> records = response.BulkData;
                return records;

            }
            catch (Exception exception)
            {

                return null;
            }
                
        }

        public List<ZCRMField> GetFields(string crmModuleName)
        {
            try
            {
                ZCRMModule moduleIns = ZCRMModule.GetInstance(crmModuleName); //module api name
                BulkAPIResponse <ZCRMField> response= moduleIns.GetAllFields(); //3372164000000190001 is record id
                List<ZCRMField> records = response.BulkData;

                return records;
            }
            catch (Exception exception)
            {

                return null;
            }
        }

        public ZCRMRecord GetSpecificRecord(string crmModuleName, long recordId)
        {
            try
            {
                ZCRMModule moduleIns = ZCRMModule.GetInstance(crmModuleName); //module api name
                APIResponse response = moduleIns.GetRecord(recordId); //3372164000000190001 is record id
                ZCRMRecord record = (ZCRMRecord)response.Data;

                return record;
            }
            catch (Exception exception)
            {

                return null;
            }
        }
    }
}
