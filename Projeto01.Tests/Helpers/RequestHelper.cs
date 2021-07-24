using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Tests.Helpers
{
    public class RequestHelper
    {
        public static StringContent Create(object request)
        {
            return new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
        }
    }
}
