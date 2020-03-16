using CMS.Domain.SeedWork;
using System;

namespace CMS.Domain.Models.CowAggregate
{
    public class Insemination : Entity
    {
        public Cow Father { get; private set; }
        public Cow Mather { get; private set; }
        public bool ByDoctor { get; private set; }
        public DateTime Date { get; private set; }
        public CowType? CowType { get; set; }

        private long MatherId;
        private long? FatherId;
    }
}
