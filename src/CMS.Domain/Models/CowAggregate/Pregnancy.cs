using CMS.Domain.SeedWork;
using System;

namespace CMS.Domain.Models.CowAggregate
{
    public class Pregnancy : Entity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime SuggestedeEndDate { get; private set; }
        public Cow Child { get; private set; }
        public Insemination Insemination { get; private set; }
        public CowType CowType { get; private set; }
        public long? ChildId { get; private set; }
        public long? InseminationId { get; private set; }
    }
}
