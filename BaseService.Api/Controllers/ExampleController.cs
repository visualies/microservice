using System.Collections.Generic;
using System.Threading.Tasks;
using BaseService.Core;
using BaseService.Core.Entities.RequestEntity;
using BaseService.Core.Entities.ResponseEntity;
using BaseService.Core.Messages;
using BaseService.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace BaseService.Api.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        private readonly IMessageService _messageService;

        public ExampleController(IExampleService exampleService, IMessageService messageService)
        {
            _exampleService = exampleService;
            _messageService = messageService;
        }

        [Route("/api/example/")]
        public async Task<IActionResult> Find([FromQuery] ExampleRequest request)
        {
            var example = await _exampleService.FindAsync(request);
            var response = TinyMapper.Map<List<ExampleResponse>>(example);

            _messageService.PublishMessage(example,"hello", "hello");

            return Ok(response);
        }
    }
}
