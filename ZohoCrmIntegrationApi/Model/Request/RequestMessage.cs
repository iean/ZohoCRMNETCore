using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZohoCrmIntegrationApi.Model.Request
{
    public class RequestMessage<T>
    {
        public long ClientId { get; set; }
        public string AppId { get; set; }
        public string UserId { get; set; }
        public T Request { get; set; }
    }
}
