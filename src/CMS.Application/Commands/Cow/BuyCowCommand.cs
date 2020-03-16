using MediatR;
using System;

namespace CMS.Application.Commands.Cow
{
    public class BuyCowCommand : IRequest
    {
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EarningNumber { get; set; }
    }
}
