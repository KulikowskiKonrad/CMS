using CMS.Domain.Models.CowAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Domain.SeedWork
{
    public abstract class Entity
    {
        public long Id { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
