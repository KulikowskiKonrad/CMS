using CMS.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cows
{
    public class BuyCowCommandHandler : IRequest<BuyCowCommand>
    {
        private readonly CMSDbContext _context;
        public BuyCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BuyCowCommand request, CancellationToken cancellationToken)
        {
            var cowToBuy = Domain.Models.CowAggregate.Cow.FromBought(request.Price, request.Weight, request.DateOfBirth, request.EarningNumber);
            _context.Add(cowToBuy);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
