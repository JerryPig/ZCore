using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Entity;

namespace ZDomain.Model
{
    public class Supplier : Entity<int>
    {
        public string SupplierName { get; set; }

        public string ShortName { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Remark { get; set; }

        public bool Status { get; set; }

        public string SupplierType { get; set; }
    }
}
