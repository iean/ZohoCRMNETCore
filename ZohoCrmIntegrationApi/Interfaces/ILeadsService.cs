using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.CRUD;
using ZohoCrmIntegrationApi.Model.Request;

namespace ZohoCrmIntegrationApi.Interfaces
{
    public interface ILeadsService : IRecordsInterface
    {
        ZCRMRecord CreateLead(LeadRequest leadRequest);
    }
}
