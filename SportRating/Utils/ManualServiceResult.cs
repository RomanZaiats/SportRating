using ServicesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http;

namespace SportRating.Utils
{
    //public class ManualServiceResult : IHttpActionResult
    //{
    //    private ServiceRespone _serviceResponse;

    //    public ManualServiceResult(ServiceRespone response)
    //    {
    //        _serviceResponse = response;
    //    }

    //    public IHttpActionResult ExecuteAsync(CancellationToken cancellationToken)
    //    {
    //        // объект ответа
    //        var response = new HttpResponseMessage();
    //        response.Content.
    //        // создаем ответ
    //        response.Content = new StringContent(bookInfo);
    //        // отмечаем, что ответ будет в виде html
    //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
    //        var res = new OkNegotiatedContentResult<object>()
    //        return new OkResult(_serviceResponse.Value);
    //    }
    //}
}