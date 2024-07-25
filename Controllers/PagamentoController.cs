using GestorMegaTv.Controllers.ReactAdminController;
using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GestorMegaTv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ReactAdminController<Pagamento>
    {
        public PagamentosController(AppDatabase context) : base(context)
        {
            _table = _context.Pagamentos;
        }
    }
}
