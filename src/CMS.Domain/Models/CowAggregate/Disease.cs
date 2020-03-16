using CMS.Domain.SeedWork;
using System;

namespace CMS.Domain.Models
{
    public class Disease : Entity
    {
        public string Name { get; private set; }
        public string Cure { get; private set; }
        public DateTime? SuggestedExpiriedDate { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }
        public Cow Cow { get; private set; }
        public long CowId { get; private set; }

        internal Disease()
        {

        }
    }
}
