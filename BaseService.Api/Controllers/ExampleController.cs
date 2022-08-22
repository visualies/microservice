using BaseService.Core.Entities.Example;
using BaseService.Core.Messages;
using BaseService.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseService.Api.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private readonly IMessageService _messageService;
        private readonly ISnowflakeService _snowflake;

        public ExampleController(IExampleService exampleService, IMessageService messageService, ISnowflakeService snowflake)
        {
            _exampleService = exampleService;
            _messageService = messageService;
            _snowflake = snowflake;
        }

        [HttpGet]
        [Route("/api/example/")]
        public async Task<IActionResult> Find([FromQuery] ExampleRequest request)
        {
            var example = await _exampleService.FindAsync(request);
            var response = TinyMapper.Map<List<ExampleResponse>>(example);

            _messageService.PublishMessage(example, "example", "example");

            return Ok(response);
        }

        [HttpGet]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            var example = await _exampleService.GetAsync(id);

            return Ok(TinyMapper.Map<ExampleResponse>(example));
        }

        [HttpPost]
        [Route("/api/example/")]
        public async Task<IActionResult> Post([FromQuery] ExampleRequest request)
        {
            if (request.Name == null) return BadRequest($"parameter name is required.");

            var example = TinyMapper.Map<Example>(request);
            example.Id = _snowflake.GenerateId();

            await _exampleService.CreateAsync(example);

            return Ok();
        }

        [HttpPatch]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Patch(ulong id, [FromQuery] ExampleRequest request)
        {
            var example = await _exampleService.GetAsync(id);

            if (example == null) return NotFound($"Example {id} was not found.");
            if (request.Name != null) example.Name = request.Name;
            if (request.LastName != null) example.LastName = request.LastName;

            await _exampleService.UpdateAsync(example);

            return Ok(TinyMapper.Map<ExampleResponse>(example));
        }

        [HttpDelete]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var example = await _exampleService.GetAsync(id);

            if (example == null) return NotFound($"Example {id} was not found.");

            await _exampleService.DeleteAsync(id);

            return Ok(TinyMapper.Map<ExampleResponse>(example));
        }
    }
}
