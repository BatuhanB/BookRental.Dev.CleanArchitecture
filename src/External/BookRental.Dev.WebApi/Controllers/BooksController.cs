﻿using BookRental.Dev.Application.Features.Book.Command.Create;
using BookRental.Dev.Application.Features.Book.Queries.GetBookById;
using BookRental.Dev.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.Dev.WebApi.Controllers
{

    public class BooksController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var getBookQuery = new GetBookByIdQuery() { Id = id };
            return Ok(await Mediator.Send(getBookQuery));
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookCommandResponse>> Create(
            [FromBody] CreateBookCommand createBookCommand)
        {
            var response = await Mediator.Send(createBookCommand);
            return Ok(response);
        } 
    }
}
