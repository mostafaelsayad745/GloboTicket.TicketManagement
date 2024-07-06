using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class EventsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EventsController(IMediator mediator)
        {
			_mediator = mediator;
		}


		[HttpGet(Name = "GetAllEvents")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<List<EventListVM>>> GetAllEvents()
		{
			var result = await _mediator.Send(new GetEventsListQuery());
			return Ok(result);
		}

		// GET: api/Events/{id}
		// Get event by id
		[HttpGet("{id}", Name = "GetEventById")]
		public async Task<ActionResult<EventListVM>> GetEventById(Guid id)
		{
			var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
			return Ok(await _mediator.Send(getEventDetailQuery));
		}

		// POST: api/Events
		// Add a new event
		[HttpPost(Name = "AddEvent")]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
		{
			var id = await _mediator.Send(createEventCommand);
			return Ok(id);
		}

		// PUT: api/Events
		// Update an existing event
		[HttpPut(Name ="UpdateEvent")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
		{
			await _mediator.Send(updateEventCommand);
			return NoContent();
		}

		// DELETE: api/Events/{id}
		// Delete an existing event
		[HttpPut("{id}", Name = "DeleteEvent")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid id)
		{
			var deleteEventCommand = new DeleteEventCommand() { EventId = id };
			await _mediator.Send(deleteEventCommand);
			return NoContent();
		}


		[HttpGet("export", Name = "ExportEvents")]
		public async Task<FileResult> ExportEvents()
		{
			var fileDto = await _mediator.Send(new GetEventsExportQuery());
			return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
		}
	}
}
