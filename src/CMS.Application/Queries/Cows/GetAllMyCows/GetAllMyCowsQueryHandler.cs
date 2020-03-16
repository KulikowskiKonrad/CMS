using AutoMapper;
using CMS.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Queries.Cows.GetAllMyCows
{
    public class GetAllMyCowsQueryHandler : IRequestHandler<GetAllMyCowsQuery, List<CowDTO>>
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMyCowsQueryHandler(CMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CowDTO>> Handle(GetAllMyCowsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return _mapper.ProjectTo<CowDTO>(_context.Cows).ToList();
         //   return _context.Cows.Select(c => new CowDTO() { EarningNumber = c.EarningNumber, Id = c.Id, Status = c.Status, Weight = c.Weight }).ToList();
        }
    }
}
