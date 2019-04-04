using System;
using System.Collections.Generic;
using System.Text;
using ZDomain.Entity;

namespace ZDomain.Model
{
    public class SupplierType : Entity<int>
    {
        public int TypeCode { get; set; }

        public int TypeName { get; set; }
    }
}
