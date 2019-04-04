using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SupplierServer.Dto
{
    public class SupplierPageDto : PageDto
    {
        public string Name { get; set; }

        public string TypeCode { get; set; }
    }
}
