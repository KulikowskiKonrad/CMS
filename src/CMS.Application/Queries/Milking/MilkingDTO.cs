using CMS.Domain.Models.CowAggregate;
using System;

namespace CMS.Application.Queries.Milking
{
    public class MilkingDTO
    {
        public long Id { get; set; }
        public int Volume { get; set; }
        public Cow CowPseudo { get; set; }
        public DateTime AdditionTime { get; set; }
        public string EarningNumber { get; set; }
    }
}
