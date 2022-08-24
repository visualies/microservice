using AutoMapper;
using BaseService.Core.Entities;
using BaseService.Core.Requests;
using BaseService.Core.Services;

namespace BaseService.Api.Resolvers
{
    public class IdResolver : IValueResolver<RequestBase, EntityBase, ulong>
    {
        private readonly ISnowflakeService _snowflake;

        public IdResolver(ISnowflakeService snowflake)
        {
            _snowflake = snowflake;
        }

        public ulong Resolve(RequestBase source, EntityBase destination, ulong destMember, ResolutionContext context)
        {
            return _snowflake.GenerateId();
        }
    }
}
