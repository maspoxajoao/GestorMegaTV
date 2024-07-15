using GestorMegaTv.Controllers.ReactAdminController;
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
    public class PlayersController : ReactAdminController<Player>
    {
        public PlayersController(AppDatabase context) : base(context)
        {
            _table = _context.Players;
        }
    }
}
