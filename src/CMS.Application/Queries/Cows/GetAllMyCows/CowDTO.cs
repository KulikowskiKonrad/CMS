using CMS.Domain;
using CMS.Domain.Models.CowAggregate;

namespace CMS.Application.Queries.Cows.GetAllMyCows
{
    public class CowDTO
    {
        public long Id { get; set; }
        public string EarningNumber { get; set; }
        public CowStatus Status { get; set; }
        public double? Weight { get; set; }
    }
}
