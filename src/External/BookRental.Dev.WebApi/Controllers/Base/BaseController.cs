using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.Dev.WebApi.Controllers.Base
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
