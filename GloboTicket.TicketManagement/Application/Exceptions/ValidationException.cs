﻿

using FluentValidation.Results;


namespace GloboTicket.TicketManagement.Application.Exceptions
{
	public class ValidationException : Exception
	{
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
			{
				ValidationErrors.Add(error.ErrorMessage);
			}
        }
    }
}
