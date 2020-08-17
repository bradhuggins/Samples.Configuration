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
        [Route("", Name = "GetSampleAppSettingsValue")]
        public string GetSampleAppSettingsValue()
        {
            return ConfigurationManager.AppSettings["samplekey"].ToString();
        }

        [Route("appSettings/{key}", Name = "GetByKey")]
        public string GetAppSettingsByKey([FromUri] string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        [Route("connectionString/{key}", Name = "GetConnectionStringByKey")]
        public string GetConnectionStringByKey([FromUri] string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();
        }

    }
}
