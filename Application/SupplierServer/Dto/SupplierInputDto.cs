using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.SupplierServer.Dto
{
    public class SupplierInputDto
    {
        public string Id { get; set; }
        [Required, MaxLength(50)]
        public string SupplierName { get; set; }
        [Required, MaxLength(50)]
        public string ShortName { get; set; }
        [MaxLength(50)]
        public string Province { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public bool Status { get; set; }

        public string SupplierType { get; set; }

    }
}
