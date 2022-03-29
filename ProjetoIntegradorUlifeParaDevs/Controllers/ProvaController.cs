using ProjetoIntegradorUlifeParaDevs.DTOs;
using ProjetoIntegradorUlifeParaDevs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProjetoIntegradorUlifeParaDevs.Controllers
{
    public class ProvaController : ApiController
    {
        private readonly ProvaService _provaService;

        public ProvaController(ProvaService provaService)
        {
            _provaService = provaService;
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IHttpActionResult> BuscarTodas()
        {
            var response = _provaService.BuscarTodas();

            return Ok(response);
        }

        [HttpGet]
        [Route("provaId")]
        [Authorize(Roles = "Professor")]
        public async Task<IHttpActionResult> BuscarPorId([FromUri] int provaId)
        {
            var response = _provaService.BuscarPorId(provaId);

            return Ok(response);
        }

        [HttpPatch]
        [Authorize(Roles = "Professor")]
        [Route("alterar-nota")]
        public async Task<IHttpActionResult> AlterarNota([FromBody] AlterarNotaRequestDto request)
        {
             _provaService.AlterarNota(request);

            return Ok();
        }
    }
}