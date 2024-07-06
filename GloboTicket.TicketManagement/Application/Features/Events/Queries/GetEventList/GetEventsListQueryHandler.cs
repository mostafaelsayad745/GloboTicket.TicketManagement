

using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _envetRepository;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> envetRepository)
        {
            _mapper = mapper;
            _envetRepository = envetRepository;
        }
        public async Task<List<EventListVM>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _envetRepository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVM>>(allEvents);
        }
    }
}
