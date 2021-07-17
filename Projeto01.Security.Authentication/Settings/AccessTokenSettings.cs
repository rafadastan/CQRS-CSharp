using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Security.Authentication.Settings
{
    public class AccessTokenSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationInHours { get; set; }
    }
}
