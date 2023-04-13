using AutoMapper;
using BaseService.Api.Requests.Create;
using BaseService.Api.Requests.Update;
using BaseService.Api.Resolvers;
using BaseService.Core.Entities;
using BaseService.Core.QueryParams;
using BaseService.Core.Requests;
using BaseService.Core.Responses;

namespace BaseService.Api.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleResponse>();

            CreateMap<ExampleReadRequest, ExampleQuery>();
            
            CreateMap<ExampleCreateRequest, Example>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<IdResolver>());

            CreateMap<ExampleUpdateRequest, Example>();
        }
    }
}
