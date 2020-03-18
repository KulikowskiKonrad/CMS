using MediatR;
using System;

namespace CMS.Application.Commands.Cows
{
    public class KillCowCommand : IRequest
    {
        public long Id { get; set; }
        public DateTime DateOfDeath { get; set; }
    }
}
