using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Album.Api.Services
{
    public static class GreetingService
    {
        public static string CheckNameExists(string name)
        {
            String HostName = Dns.GetHostName();
            if (!string.IsNullOrEmpty(name))
            {
                return $"Hello {name} {HostName} v2" ;
            }

            return $"Hello World {HostName} v2";
        }

    }
}
