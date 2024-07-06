﻿

using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
	public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVM>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Event> _eventRepository;
		private readonly ICsvExporter _csvExporter;

		public GetEventsExportQueryHandler(IMapper mapper , IAsyncRepository<Event> eventRepository , ICsvExporter csvExporter)
        {
			_mapper = mapper;
			_eventRepository = eventRepository;
			_csvExporter = csvExporter;
		}
        public async Task<EventExportFileVM> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
		{
			var allEvents = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

			var fileData = _csvExporter.ExportEventsToCsv(allEvents);

			var eventExportFileDto = new EventExportFileVM() { ContentType = "text/csv",
				Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

			return eventExportFileDto;
		}
	}
}
