using MediatR;
using System.Collections.Generic;

namespace CMS.Application.Queries.Cows.GetAllMyCows
{
    public class GetAllMyCowsQuery : IRequest<List<CowDTO>>
    {
    }
}
