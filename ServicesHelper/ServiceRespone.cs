using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesHelper
{
    public enum ResponeCode { Success, NotFound, BadRequest, DbError, DbRecordCreated, DbRecordUpdated, DbRecordDeleted }

    public class ServiceRespone
    {
        public ResponeCode ResponseCode { get; set; }

        public object Value { get; set; }

        public string ErrorMessage { get; set; }
    }
}
