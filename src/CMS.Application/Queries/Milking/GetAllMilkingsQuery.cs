using CMS.Domain.Models.CowAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace CMS.Application.Queries.Milking
{
    public class GetAllMilkingsQuery : IRequest<List<MilkingDTO>>
    {
        public DateTime? AdditionDate { get; set; }
        public long? CowId { get; set; }
        public string CowPseudo { get; set; }
        public string EarningNumber { get; set; }
    }
}
