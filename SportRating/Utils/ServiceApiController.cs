using ServicesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportRating.Utils
{
    public class ServiceApiController : ApiController
    {
        public ServiceApiController(): base()
        {
        }

        public IHttpActionResult MapServiceToHttpResponse(ServiceRespone response)
        {
            switch (response.ResponseCode)
            {
                case ResponeCode.NotFound:
                    {
                        return NotFound();
                    }
                case ResponeCode.DbError:
                    {
                        return BadRequest(response.ErrorMessage);
                    }
                case ResponeCode.BadRequest:
                    {
                        return BadRequest(response.ErrorMessage);
                    }
                case ResponeCode.Success:
                    {
                        return Ok(response.Value);
                    }
                case ResponeCode.DbRecordCreated:
                    {
                        return Created(Request.RequestUri, response.Value);
                    }
                case ResponeCode.DbRecordDeleted:
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                case ResponeCode.DbRecordUpdated:
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                default:
                    {
                        return Ok(response.Value);
                    }
            }
        }
    }
}
