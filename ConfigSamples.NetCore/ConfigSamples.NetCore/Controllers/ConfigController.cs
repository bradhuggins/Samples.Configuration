using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigSamples.NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        internal readonly IConfiguration _config;
        public ConfigController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("", Name = "Get")]
        public IActionResult Get()
        {
            string result = _config.GetValue<string>("samplekey");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{key}", Name = "GetByKey")]
        public IActionResult GetByKey(string key)
        {
            string result = _config.GetValue<string>(key);
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("ini", Name = "GetFromIni")]
        public IActionResult GetFromIni()
        {
            string result = _config.GetValue<string>("samplekeyini");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("json", Name = "GetFromJson")]
        public IActionResult GetFromJson()
        {
            string result = _config.GetValue<string>("samplekeyjson");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("xml", Name = "GetFromXml")]
        public IActionResult GetFromXml()
        {
            string result = _config.GetValue<string>("samplekeyxml");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("memory", Name = "GetFromMemory")]
        public IActionResult GetFromMemory()
        {
            string result = _config.GetValue<string>("samplekeymemory");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("env", Name = "GetFromEnvironment")]
        public IActionResult GetFromEnvironment()
        {
            string result = _config.GetValue<string>("samplekeyenv");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("hierarchical", Name = "GetHierarchicalValue")]
        public IActionResult GetHierarchicalValue()
        {
            string result = _config.GetValue<string>("samplesection:key1");
            if (string.IsNullOrEmpty(result))
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
