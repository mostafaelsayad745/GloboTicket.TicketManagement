

namespace GloboTicket.TicketManagement.Domain.Common
{
	// implement the AuditableEntity class to make every entity in the domain have a logging support for tracking purposes in the database
	public class AuditableEntity
	{
		public string? CreatedBy { get; set; }
		public DateTime Created { get; set; }
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModified { get; set; }
	}
}
