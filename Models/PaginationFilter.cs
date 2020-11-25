using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_REST_API.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int Page_Size { get; set; }

        public string Filter { get; set; }
        public string Sort_Order { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.Page_Size = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.Page_Size = pageSize > 10 ? 10 : pageSize;
        }
    }
}
