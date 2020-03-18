using CMS.Domain.Models.CowAggregate;
using CMS.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cows
{
    public class NewCowCommandHandler : IRequestHandler<NewCowCommand>
    {
        private readonly CMSDbContext _context;
        public NewCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewCowCommand request, CancellationToken cancellationToken)
        {
            var newCow = new Cow(request.EarningNumber, request.DateOfBirth, request.PassportNumber, request.CowshedId);
            _context.Add(newCow);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
