﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> values = new List<string>();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] string q)
        {
            if(!string.IsNullOrEmpty(q))
            {
                return values.Where(value => value.Contains(q, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return values[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            values.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            values[id] = value;
        }

        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] string value)
        {
            values[id] = "patch:" + value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }
}
