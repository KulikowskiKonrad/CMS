using AutoMapper;
using CMS.Application.Queries.Cows.GetAllMyCows;
using CMS.Domain.Models.CowAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cow, CowDTO>()
                .ForMember(d => d.Status, opt => opt.MapFrom(d => d.Status.ToString()));
        }
    }
}
