using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConfigSamples.Framework.Controllers
{
    public class ConfigController : ApiController
    {
        [Route("", Name = "GetSampleKeyValue")]
        public string GetSampleKeyValue()
        {
            return ConfigurationManager.AppSettings["samplekey"].ToString();
        }

        [Route("getbykey", Name = "GetByKey")]
        public string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        [Route("getconnectionstringbyKey", Name = "GetConnectionStringByKey")]
        public string GetConnectionStringByKey(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();
        }

    }
}
