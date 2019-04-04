using System;
using System.Collections.Generic;
using System.Text;

namespace ZDomain.Entity
{
    public interface IEntity
    {

    }

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
