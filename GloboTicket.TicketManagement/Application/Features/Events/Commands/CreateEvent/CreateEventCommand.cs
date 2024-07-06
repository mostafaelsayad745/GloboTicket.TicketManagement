﻿

using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
	public class CreateEventCommand : IRequest<Guid>
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public DateTime Date { get; set; }
		public Guid CategoryId { get; set; }
		public int Price { get; set; }
		public string? Artist { get; set; }
		public string? ImageUrl { get; set; }

		public override string ToString()
		{
			return $"Event Name: {Name}; Date: {Date}; By: {Artist}; On: { Date.ToShortDateString()}; Description: { Description}" ;
		}
	}
}
