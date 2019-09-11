using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCRMSDK.CRM.Library.Api;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.CRUD;
using ZCRMSDK.CRM.Library.Setup.RestClient;
using ZCRMSDK.OAuth.Client;
using ZCRMSDK.OAuth.Contract;
using ZohoCrmIntegrationApi.Interfaces;
using ZohoCrmIntegrationApi.Interfaces.implementation;
using ZohoCrmIntegrationApi.Model.Request;

namespace ZohoCrmIntegrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZohoController : ControllerBase
    {
        IConfigurationService configurationService;
        IRecordsInterface _recordService;
        ILeadsService leadsService;
        public ZohoController(IConfigurationService service, IRecordsInterface recordsInterface, ILeadsService leadsService)
        {
            this.configurationService = service;
            this._recordService = recordsInterface;
            this.leadsService = leadsService;
        }
        // GET: api/Zoho
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Zoho/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }



        [HttpGet("", Name = "Modules")]
        [Route("modules")]
        public List<ZCRMModule> modules()
        {
            try
            {
                this.AuthorizeZoho();
                ZCRMRestClient restClient = ZCRMRestClient.GetInstance();
                BulkAPIResponse<ZCRMModule> response = restClient.GetAllModules();
                List<ZCRMModule> modules = response.BulkData; // modules - list of ZCRMModule instances
                return modules;
            }
            catch (Exception exception)
            {

                throw;
            }
        }


        [HttpGet("", Name = "leads")]
        [Route("leads")]
        public List<ZCRMRecord> leads()
        {
            try
            {
                AuthorizeZoho();
                return this._recordService.GetAllRecords(ZohoConstants.LEAD_MODULE_STRING);
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        private void AuthorizeZoho()
        {
            var config = this.configurationService.GetZohoConfiguration();
            this.configurationService.InitializeZoho(config);
        }

        [HttpGet("{module}", Name = "fields")]
        [Route("fields/{module}")]
        public List<ZCRMField> Fields(string module)
        {
            try
            {
                this.AuthorizeZoho();
                return this._recordService.GetFields(module);
            }
            catch (Exception exception)
            {

                throw;
            }
        }


        // POST: api/Zoho
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // POST: api/Zoho
        [HttpPost]
        [Route("leads/create")]
        public ZCRMRecord Create([FromBody] RequestMessage<LeadRequest> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (value.Request == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            else
            {
                this.AuthorizeZoho();
                return this.leadsService.CreateLead(value.Request);
            }
        }




        // PUT: api/Zoho/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
