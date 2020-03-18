using CMS.Infrastructure;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cows
{
    public class SellCowCommandHandler : IRequestHandler<SellCowCommand>
    {
        private readonly CMSDbContext _context;

        public SellCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SellCowCommand request, CancellationToken cancellationToken)
        {
            var cowToSell = _context.Cows.Where(x => x.Id == request.Id).SingleOrDefault();
            cowToSell.Sell(request.Price, request.Weight, request.DateOfSold);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
