using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.CRUD;
using ZCRMSDK.CRM.Library.Setup.Users;
using ZohoCrmIntegrationApi.Model.Request;

namespace ZohoCrmIntegrationApi.Interfaces.implementation
{
    public class LeadsService : ZohoRecordsService, ILeadsService
    {
        public ZCRMRecord CreateLead(LeadRequest leadRequest)
        {
            ZCRMRecord record = ZCRMRecord.GetInstance(ZohoConstants.LEAD_MODULE_STRING, null); 
            record.SetFieldValue("Last_Name", leadRequest.Name); //This method use to set FieldApiName and value similar to all other FieldApis and Custom field
            record.SetFieldValue("Email", leadRequest.Email);
            record.SetFieldValue("Description", leadRequest.Description);
            record.SetFieldValue("Email_Opt_Out", true);
            record.SetFieldValue("No_of_Employees", leadRequest.NumberOfEmployees);
            ZCRMUser owner = ZCRMUser.GetInstance(680990340);//User Id
            record.Owner = owner;
            APIResponse responseIns = record.Create();//To call the create record method
            ZCRMRecord record1 = (ZCRMRecord)responseIns.Data;
            return record1;
        }
    }
}
