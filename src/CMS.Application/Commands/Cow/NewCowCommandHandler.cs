using CMS.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cow
{
    public class NewCowCommandHandler : IRequest<NewCowCommand>
    {
        private readonly CMSDbContext _context;
        public NewCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewCowCommand request, CancellationToken cancellationToken)
        {
            var newCow = new Domain.Models.Cow(request.EarningNumber, request.DateOfBirth);
            _context.Add(newCow);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
