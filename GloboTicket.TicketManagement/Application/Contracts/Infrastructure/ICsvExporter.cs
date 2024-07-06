

using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
	// is used to export all events to csv file
	public interface ICsvExporter
	{
		byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos );
	}
}
