using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Domain.Models;
using CMS.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CowController : ControllerBase
    {
        private readonly CMSDbContext _context;

        public CowController(CMSDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult New(NewCowCommand command)
        {
            try
            {
                var cow = new Cow(command.earningNumber, command.dateOfBirth);
                _context.Add(cow);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Kill(KillCowCommand command)
        {
            try
            {
                var deathCow = _context.Cows.Where(x => x.Id == command.Id).SingleOrDefault();
                deathCow.Kill(command.DateOfDeath);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Sell(SellCowCommand command)
        {
            try
            {
                var cowToSell = _context.Cows.Where(x => x.Id == command.Id).SingleOrDefault();
                cowToSell.Sell(command.Price, command.Weight, command.DateOfSold);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Buy(BuyCowCommand command)
        {
            try
            {
                var cow = Cow.FromBought(command.Price, command.Weight, command.DateOfBirth, command.EarningNumber);
                _context.Add(cow);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

    public class NewCowCommand
    {
        public string earningNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
    }

    public class KillCowCommand
    {
        public long Id { get; set; }
        public DateTime DateOfDeath { get; set; }
    }

    public class SellCowCommand
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfSold { get; set; }
    }

    public class BuyCowCommand
    {
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EarningNumber { get; set; }
    }
}