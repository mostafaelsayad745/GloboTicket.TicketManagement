
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
	public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
	{
		private readonly IEventRepository _eventRepository;

		public CreateEventCommandValidator(IEventRepository eventRepository)
		{

			_eventRepository = eventRepository;

			RuleFor(e => e.Name)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(e => e.Date)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.GreaterThan(DateTime.Now).WithMessage("{PropertyName} should be a future date.");

			RuleFor(e => e.Price)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

			RuleFor(e => e.Artist)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

			// custom validation 
			RuleFor(e => e).MustAsync(EventNameAndDateUnique)
				.WithMessage("An event with the same name and date already exists.");
			
		}

		private async Task<bool> EventNameAndDateUnique(CreateEventCommand e , CancellationToken token)
		{
			return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
		}
	}
}
