﻿
using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport
{
	public class CsvExporter : ICsvExporter
	{
		public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (var streamWriter = new StreamWriter(memoryStream))
			{
				using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
				csvWriter.WriteRecords(eventExportDtos);
			}
			return memoryStream.ToArray();
		}
	}
}
