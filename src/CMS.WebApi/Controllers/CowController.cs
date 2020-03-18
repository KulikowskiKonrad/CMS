using System;
using System.Threading.Tasks;
using CMS.Application.Commands.Cows;
using CMS.Application.Queries.Cows.GetAllMyCows;
using CMS.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CowController : ControllerBase
    {
        private readonly CMSDbContext _context;
        private readonly IMediator _mediator;

        public CowController(CMSDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> New(NewCowCommand command)
        {
            try
            {
                await _mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Kill(KillCowCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sell(SellCowCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCowsList()
        {
            try
            {
                var cowsList = await _mediator.Send(new GetAllMyCowsQuery());
                return Ok(cowsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyCowCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}