using GestorMegaTv.Controllers.ReactAdminController;
using GestorMegaTv.Models;
using GestorMegaTv.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;

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
            var ultimaPosicao = _context.CampanhaMidias
                .Where(c => c.CampanhaId == campanhaId)
                .Max(c => c.Posicao) + 1;
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

        [HttpPost("mover/{direcao}")]
        public ActionResult MoverMidias([FromRoute] string direcao, [FromBody] int[] ids)
        {
            // pega as midias da campanha que estao sendo movidas
            var midiasCampanhaMovidas = _context.CampanhaMidias.Where(cm => ids.Contains(cm.Id)).OrderBy(cm => cm.Posicao).ToList();
            if (!midiasCampanhaMovidas.Any())
            {
                return BadRequest("Nenhuma mídia encontrada para os IDs fornecidos.");
            }

            // pega as midias restantes na campanha
            var midiasRestantesDaCampanha = _context.CampanhaMidias.Where(c => c.CampanhaId == midiasCampanhaMovidas.First().CampanhaId && !ids.Contains(c.Id)).OrderBy(cm => cm.Posicao).ToList();

            // total de mídias na campanha
            var totalMidiasCampanha = _context.CampanhaMidias.Count(c => c.CampanhaId == midiasCampanhaMovidas.First().CampanhaId);

            // array para guardar as novas posiçoes das midias
            CampanhaMidia[] novaListaCampanha = new CampanhaMidia[totalMidiasCampanha];

            foreach (var midia in midiasCampanhaMovidas)
            {
                int novaPosicao;
                if (direcao == "cima")
                {
                    novaPosicao = midia.Posicao.Value - 1 >= 0 ? midia.Posicao.Value - 1 : 0;
                }
                else if (direcao == "baixo")
                {
                    novaPosicao = midia.Posicao.Value + 1 < totalMidiasCampanha ? midia.Posicao.Value + 1 : midia.Posicao.Value;
                }
                else
                {
                    return BadRequest("Direção inválida. Use 'cima' ou 'baixo'.");
                }

                // ajustar a posiçao se ja estiver ocupada
                while (novaPosicao+1 < novaListaCampanha.Length && novaListaCampanha[novaPosicao] != null)
                {
                        novaPosicao++;
                }

                midia.Posicao = novaPosicao;
                novaListaCampanha[novaPosicao] = midia;
            }

            int posicao = 0;
            foreach (var campanhaMidia in midiasRestantesDaCampanha)
            {
                while (novaListaCampanha[posicao] != null)
                {
                    if (posicao + 1 >= novaListaCampanha.Length)
                        posicao = 0;
                    else
                        posicao++;
                }
                campanhaMidia.Posicao = posicao;
                novaListaCampanha[posicao] = campanhaMidia;
            }

            _context.SaveChanges();



            AtualizarPosicoes(midiasCampanhaMovidas.First().CampanhaId.Value);

            return Ok(midiasCampanhaMovidas);
        }

        public void AtualizarPosicoes(int campanhaId)
        {
            var midiasCampanha = _context.CampanhaMidias
                .Where(c => c.CampanhaId == campanhaId)
                .OrderBy(c => c.Posicao)
                .ToList();
            int index = 0;
            foreach (var midiaCampanha in midiasCampanha)
            {
                midiaCampanha.Posicao = index;
                index++;
            }
            _context.SaveChanges();
        }
    }
}
