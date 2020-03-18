using CMS.Domain.SeedWork;
using System;

namespace CMS.Domain.Models.CowAggregate
{
    public class Milking : Entity
    {
        public DateTime AdditionTime { get; private set; }
        public short Volume { get; private set; }
        public Cow Cow { get; private set; }
        public long CowId { get; private set; }

        private Milking()
        {

        }

        internal Milking(DateTime milkingDate, short volume)
        {
            Volume = volume;
            AdditionTime = milkingDate;
        }
    }
}
