using MediatR;
using System;

namespace CMS.Application.Commands.Milking
{
    public class NewMilkingCommand : IRequest
    {
        public short Volume { get; set; }
        public DateTime AdditionDate { get; set; }
        public long CowId { get; set; }
    }
}
