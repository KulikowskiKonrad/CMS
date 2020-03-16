using CMS.Domain.SeedWork;
using System;

namespace CMS.Domain.Models.CowAggregate
{
    public class Milking : Entity
    {
        public DateTime? AdditionTime { get; private set; }
        public short Volume { get; private set; }
    }
}
