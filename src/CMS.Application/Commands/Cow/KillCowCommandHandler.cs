using CMS.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Cow
{
    public class KillCowCommandHandler : IRequest<KillCowCommand>
    {
        private readonly CMSDbContext _context;
        public KillCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(KillCowCommand request, CancellationToken cancellationToken)
        {
            var deathCow = _context.Cows.Where(x => x.Id == request.Id).SingleOrDefault();
            deathCow.Kill(request.DateOfDeath);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
