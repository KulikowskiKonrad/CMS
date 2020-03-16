using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Domain.Models
{
    public class Disease
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Cure { get; private set; }
        public DateTime? SuggestedExpiriedDate { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }
        public Cow Cow { get; private set; }
        private long CowId;

        internal Disease()
        {

        }
    }
}
