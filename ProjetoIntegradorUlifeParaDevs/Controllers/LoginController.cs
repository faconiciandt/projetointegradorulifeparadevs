using ProjetoIntegradorUlifeParaDevs.DTOs.Autenticacao;
using ProjetoIntegradorUlifeParaDevs.Repositories;
using ProjetoIntegradorUlifeParaDevs.Services.Autenticacao;
using Microsoft.IdentityModel;
using System.Threading.Tasks;
using System.Web.Http;
using ProjetoIntegradorUlifeParaDevs.Helpers;
using System.Security.Cryptography;

namespace ProjetoIntegradorUlifeParaDevs.Controllers
{
    public class LoginController : ApiController
    {
        private UsuarioRepository _usuarioRepository;
        private TokenService _tokenService;

        public LoginController(UsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login([FromBody] LoginDto model)
        {
            var senhaCrypto = CryptoHelper.ComputeHash(model.Senha, new SHA256CryptoServiceProvider());

            var usuario = _usuarioRepository.ValidaUsuario(model.Email, senhaCrypto);

            if (usuario == null)
                return BadRequest("Usuário ou Senha invalidos");

            var token = _tokenService.GerarToken(usuario);

            return Ok(new { token });
        }
    }
}