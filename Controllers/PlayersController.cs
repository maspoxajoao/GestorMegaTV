using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestorMegaTv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AppDatabase _Context;

        public PlayersController(AppDatabase context)
        {
            _Context = context;
        }
        [HttpGet]
        public List<Player> Get()
        {
            return _Context.Players.ToList();
        }
    }
}
