using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class StageController : ApiController
    {
        // GET: api/Stage
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stage/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage/5
        public void Delete(int id)
        {
        }
    }
}
