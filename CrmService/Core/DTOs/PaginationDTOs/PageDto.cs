using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.PaginationDTOs
{
    public class PageDto
    {
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
    }
}
