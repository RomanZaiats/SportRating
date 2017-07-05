using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class MatchController : ApiController
    {
        // GET: api/Match
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Match/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Match
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Match/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Match/5
        public void Delete(int id)
        {
        }
    }
}
