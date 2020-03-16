using MediatR;
using System;

namespace CMS.Application.Commands.Cow
{
    public class NewCowCommand : IRequest
    {
        public string EarningNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
