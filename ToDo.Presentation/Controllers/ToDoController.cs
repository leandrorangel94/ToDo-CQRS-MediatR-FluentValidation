using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.ToDo.Commands.Create;
using ToDo.Application.ToDo.Queries.GetAll;
using ToDo.Application.ToDo.Queries.GetById;
using ToDo.Application.ViewModel;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/todo")]
    public class ToDoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IList<ToDoViewModel>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }

        [Route("{id}")]
        [HttpGet]
        [ActionName("GetById")]
        public async Task<IActionResult> GetToDoById(int id)
        {
            var query = new GetToDoByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("create")]
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateToDo([FromBody] CreateToDoCommand command)
        {
            if (command == null)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        [Route("atualizar")]
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateToDo([FromBody] UpdateToDoCommand command)
        {
            if (command == null)
                return BadRequest();

            return Ok(await _mediator.Send(command));
        }

        [Route("remover/{id}")]
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            await _mediator.Send(new RemoveToDoCommand { Id = id });
            return NoContent();
        }
    }
}