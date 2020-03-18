using CMS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Milking
{
    class NewMilkingCommandHandler : IRequest<NewMilkingCommand>
    {
        private readonly CMSDbContext _context;

        public NewMilkingCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewMilkingCommand request, CancellationToken cancellationToken)
        {
            var cow = _context.Cows.Include(x => x.Milkings).Where(x => x.Id == request.CowId).SingleOrDefault();
            cow.AddMilking(request.AdditionDate, request.Volume);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
