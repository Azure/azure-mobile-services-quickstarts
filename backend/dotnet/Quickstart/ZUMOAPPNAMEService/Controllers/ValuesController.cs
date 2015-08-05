using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.Azure.Mobile.Server.Config;

namespace ZUMOAPPNAMEService.Controllers
{
    // Use the MobileAppController attribute for each ApiController you want to use  
    // from your mobile clients 
    [MobileAppController]
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            //This method of tracing replaces functionality previously provided through ApiServices
            Configuration.Services.GetTraceWriter().Info(Request, "ValuesController", "Default GET endpoint which returns 'Hello World!'");

            return "Hello World!";
        }

        // POST api/values
        public string Post()
        {
            return "Hello World!";
        }
    }
}
