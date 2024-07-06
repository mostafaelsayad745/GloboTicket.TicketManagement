﻿using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
        {
			_mediator = mediator;
		}

		// GET: api/Category/all
		// Get all categories
		[HttpGet("all",Name ="GetAllCategories")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<ActionResult<List<CategoryListVM>>> GetAllCategories()
		{
			var dtos = await _mediator.Send(new GetCategoriesListQuery());
			return Ok(dtos);
		}

		// GET: api/Category/allwithevents
		// Get all categories with events
		[HttpGet("allwithevents", Name = "GetAllCategoriesWithEvents")]
		[ProducesDefaultResponseType]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<ActionResult<List<CategoryEventListVM>>> GetAllCategoriesWithEvents(bool includeHistory)
		{
			GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery()
			{ IncludeHistory = includeHistory };

			var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
			return Ok(dtos);
		}

		// POST: api/Category
		// Add a new category
		[HttpPost(Name = "AddCategory")]
		[Authorize]
		public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
		{
			var response = await _mediator.Send(createCategoryCommand);
			return Ok(response);
		}

	}
}
