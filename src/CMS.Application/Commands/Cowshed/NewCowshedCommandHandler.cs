using CMS.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cowshed
{
    public class NewCowshedCommandHandler : IRequest<NewCowshedCommand>
    {
        private readonly CMSDbContext _context;

        public NewCowshedCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewCowshedCommand request, CancellationToken cancellationToken)
        {
            var newCowshed = new Domain.Models.CowAggregate.Cowshed(request.NumberOfPlaces, request.Name, request.DateOfBuild);
            _context.Add(newCowshed);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
//😁