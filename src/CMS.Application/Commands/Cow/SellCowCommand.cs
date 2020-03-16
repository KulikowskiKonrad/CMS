using MediatR;
using System;

namespace CMS.Application.Commands.Cow
{
    public class SellCowCommand : IRequest
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfSold { get; set; }
    }
}
