using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10.Data;
using Mission10.Models;

namespace Mission10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBowlers()
        {
            var bowlers = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null &&
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
                .Select(b => new BowlerDto
                {
                    BowlerID = b.BowlerID,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerLastName = b.BowlerLastName,
                    TeamName = b.Team!.TeamName,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber
                })
                .ToList();

            return Ok(bowlers);
        }
    }
}