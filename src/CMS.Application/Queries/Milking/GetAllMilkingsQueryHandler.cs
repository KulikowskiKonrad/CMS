using AutoMapper;
using CMS.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Queries.Milking
{
    public class GetAllMilkingsQueryHandler : IRequestHandler<GetAllMilkingsQuery, List<MilkingDTO>>
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMilkingsQueryHandler(CMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MilkingDTO>> Handle(GetAllMilkingsQuery request, CancellationToken cancellationToken)
        {
            var milkings = _context.Milkings.AsQueryable();
            if (request.AdditionDate.HasValue)
            {
                milkings = milkings.Where(x => x.AdditionTime.Date == request.AdditionDate.Value.Date);
            }

            if (request.CowId.HasValue)
            {
                milkings = milkings.Where(x => x.CowId == request.CowId);
            }

            if (string.IsNullOrEmpty(request.CowPseudo))
            {
                milkings = milkings.Where(x => x.Cow.PseudoName.ToLower() == request.CowPseudo.Trim().ToLower());
            }

            if (string.IsNullOrEmpty(request.EarningNumber))
            {
                milkings = milkings.Where(x => x.Cow.EarningNumber.ToLower() == request.EarningNumber.Trim().ToLower());
            }

            await Task.CompletedTask;

            return _mapper.ProjectTo<MilkingDTO>(milkings).ToList();
        }
    }
}
