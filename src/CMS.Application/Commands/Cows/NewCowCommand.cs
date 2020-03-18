using MediatR;
using System;

namespace CMS.Application.Commands.Cows
{
    public class NewCowCommand : IRequest
    {
        public string EarningNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
