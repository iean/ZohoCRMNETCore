using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZohoCrmIntegrationApi.Model.Request
{
    public class LeadRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
