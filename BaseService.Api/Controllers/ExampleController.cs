using AutoMapper;
using BaseService.Api.Requests.Create;
using BaseService.Api.Requests.Update;
using BaseService.Core.Entities;
using BaseService.Core.Messages;
using BaseService.Core.QueryParams;
using BaseService.Core.Requests;
using BaseService.Core.Responses;
using BaseService.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseService.Api.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public ExampleController(IExampleService exampleService, IMessageService messageService, IMapper mapper)
        {
            _exampleService = exampleService;
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/example/")]
        public async Task<IActionResult> Find([FromQuery] ExampleReadRequest request)
        {
            var query = _mapper.Map<ExampleQuery>(request);
            var example = await _exampleService.FindAsync(query);
            var response = _mapper.Map<List<ExampleResponse>>(example);

            _messageService.PublishMessage(example, "example", "example");

            return Ok(response);
        }

        [HttpGet]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            var example = await _exampleService.GetAsync(id);

            if (example == null) return NotFound($"Example {id} was not found.");

            return Ok(_mapper.Map<ExampleResponse>(example));
        }

        [HttpPost]
        [Route("/api/example/")]
        public async Task<IActionResult> Post([FromBody] ExampleCreateRequest request)
        {
            if (request.Name == null) return BadRequest($"parameter name is required.");

            var example = _mapper.Map<Example>(request);

            await _exampleService.CreateAsync(example);

            return Ok(_mapper.Map<ExampleResponse>(example));
        }

        [HttpPatch]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Patch(ulong id, [FromQuery] ExampleUpdateRequest request)
        {
            var example = await _exampleService.GetAsync(id);

            if (example == null) return NotFound($"Example {id} was not found.");
            if (request.Name != null) example.Name = request.Name;
            if (request.LastName != null) example.LastName = request.LastName;

            await _exampleService.UpdateAsync(example);

            return Ok(_mapper.Map<ExampleResponse>(example));
        }

        [HttpDelete]
        [Route("/api/example/{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var example = await _exampleService.GetAsync(id);

            if (example == null) return NotFound($"Example {id} was not found.");

            await _exampleService.DeleteAsync(id);

            return Ok(_mapper.Map<ExampleResponse>(example));
        }
    }
}
