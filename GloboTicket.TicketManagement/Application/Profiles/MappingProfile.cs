
using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Event, EventListVM>().ReverseMap();

			CreateMap<Event, EventDetailVM>().ReverseMap();
			CreateMap<Category, CategoryDto>();
			CreateMap<Category, CategoryListVM>().ReverseMap();
			CreateMap<Category, CategoryEventListVM>().ReverseMap();
			CreateMap<Event,CreateEventCommand>().ReverseMap();
			CreateMap<Event,UpdateEventCommand>().ReverseMap();
			CreateMap<Event,DeleteEventCommand>().ReverseMap();
			CreateMap<Category, CreateEventCommand>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Order, OrdersForMonthDto>().ReverseMap();

		}
	}
	
}
