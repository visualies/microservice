using AutoMapper;
using BaseService.Api.Resolvers;
using BaseService.Core.Entities;
using BaseService.Core.Requests;
using BaseService.Core.Responses;

namespace BaseService.Api.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleResponse>();

            CreateMap<ExampleRequest, Example>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<IdResolver>());
        }
    }
}
