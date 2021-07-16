using System.Threading.Tasks;
using BaseService.Core;
using BaseService.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaseService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IUnitOfWork context;

        public ExampleController(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<Example> Get(int id)
        {
            var example = await context.ExampleRepository.GetAsync(id.ToString());

            return example;
        }
    }
}
