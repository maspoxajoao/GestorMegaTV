using GestorMegaTv.Controllers.ReactAdminController;
using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GestorMegaTv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaMidiasController : ReactAdminController<CampanhaMidia>
    {
        public CampanhaMidiasController(AppDatabase context) : base(context)
        {
            _table = _context.CampanhaMidias;
        }

        [HttpPost("add/{campanhaId}")]
        public ActionResult AddCampanhaMidias([FromBody] int[] midiaIds, [FromRoute] int campanhaId)
        {
            var ultimaPosicao = _context.CampanhaMidias.Where(c => c.CampanhaId == campanhaId).Max(c => c.Posicao) +1;
            if (ultimaPosicao == null) ultimaPosicao = 0;
            CampanhaMidia novaCampanhaMidia = null;
            foreach(var midiaId in midiaIds)
            {
                novaCampanhaMidia = new CampanhaMidia()
                {
                    MidiaId = midiaId,
                    CampanhaId = campanhaId,
                    Posicao = ultimaPosicao
                };
                ultimaPosicao++;
                _context.CampanhaMidias.Add(novaCampanhaMidia);                
            }
            _context.SaveChanges();

            return Ok(novaCampanhaMidia);
        }
    }
}
