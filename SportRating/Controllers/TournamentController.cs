using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Controllers
{
    public class TournamentController : ApiController
    {
        // GET: api/Tournament
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tournament/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tournament
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tournament/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tournament/5
        public void Delete(int id)
        {
        }
    }
}
