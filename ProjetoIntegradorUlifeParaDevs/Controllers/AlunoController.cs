using ProjetoIntegradorUlifeParaDevs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProjetoIntegradorUlifeParaDevs.Controllers
{
    public class AlunoController : ApiController
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IHttpActionResult> BuscarAlunos()
        {
            var response = _alunoService.BuscarTodosAlunos();

            return Ok(response);
        }
    }
}