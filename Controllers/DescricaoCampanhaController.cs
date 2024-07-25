using GestorMegaTv.Controllers.ReactAdminController;
using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GestorMegaTv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescricaocampanhasController : ReactAdminController<Descricaocampanha>
    {
        public DescricaocampanhasController(AppDatabase context) : base(context)
        {
            _table = _context.Descricaocampanhas;
        }
    }
}
