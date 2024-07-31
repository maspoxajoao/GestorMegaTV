using GestorMegaTv.Controllers.ReactAdminController;
using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;

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
            var ultimaPosicao = _context.CampanhaMidias.Where(c => c.CampanhaId == campanhaId).Max(c => c.Posicao) + 1;
            if (ultimaPosicao == null) ultimaPosicao = 0;
            CampanhaMidia novaCampanhaMidia = null;
            foreach (var midiaId in midiaIds)
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

        [HttpPut("MoveCima/{id}")]
        public ActionResult MoveCima(int id)
        {
            var midiaAtual = _context.CampanhaMidias.Find(id);
            if (midiaAtual == null) return NotFound();

            return Ok(midiaAtual);

        }

        [HttpPut("mover/{direcao}/{id}")]
        public ActionResult MoveBaixo(string direcao, int id)
        {
            var midiaAtual = _context.CampanhaMidias.Find(id);

            if (midiaAtual == null) return NotFound();

            if (direcao == "cima")
            {

                var midiaAnterior = _context.CampanhaMidias
                    .Where(c => c.CampanhaId == midiaAtual.CampanhaId && c.Posicao < midiaAtual.Posicao)
                    .OrderByDescending(c => c.Posicao)
                    .FirstOrDefault();
                if (midiaAnterior == null) return BadRequest("Já está na posição");

                var temPos = midiaAtual.Posicao;
                midiaAtual.Posicao = midiaAnterior.Posicao;
                midiaAnterior.Posicao = temPos;

                _context.SaveChanges();

            }
            else if (direcao == "baixo")
            {

                var proximaMidia = _context.CampanhaMidias
                   .Where(c =>
                   c.CampanhaId == midiaAtual.CampanhaId
                   && c.Posicao > midiaAtual.Posicao
                   )
                   .OrderBy(c => c.Posicao)
                   .FirstOrDefault();
                if (proximaMidia == null) return BadRequest("Já na posição");

                var temPos = midiaAtual.Posicao;
                midiaAtual.Posicao = proximaMidia.Posicao;
                proximaMidia.Posicao = temPos;
            }

            _context.SaveChanges();
            AtualizarPosicoes(midiaAtual.CampanhaId.Value);

            return Ok(midiaAtual);
        }

        public void AtualizarPosicoes(int campanhaId)
        {
            var midiasCampanha = _context.CampanhaMidias.Where(c => c.CampanhaId == campanhaId).OrderBy(c=>c.Posicao).ToList();
            int index = 0;
            foreach(var midiaCampanha in midiasCampanha)
            {
                midiaCampanha.Posicao = index;
                index++;
            }
            _context.SaveChanges();
        }
    }
}
