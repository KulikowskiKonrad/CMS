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
    public class BuyCowCommandHandler : IRequest<BuyCowCommand>
    {
        private readonly CMSDbContext _context;
        public BuyCowCommandHandler(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(BuyCowCommand request, CancellationToken cancellationToken)
        {
            var cowToBuy = Domain.Models.Cow.FromBought(request.Price, request.Weight, request.DateOfBirth, request.EarningNumber);
            _context.Add(cowToBuy);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
