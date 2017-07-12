using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesHelper
{
    public enum ResponeCode { Success, NotFound, BadRequest, DbError }

    public class ServiceRespone
    {
        public ResponeCode ResponseCode { get; set; }

        public object Value { get; set; }
    }
}
