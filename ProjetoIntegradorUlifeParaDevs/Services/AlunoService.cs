using ProjetoIntegradorUlifeParaDevs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoIntegradorUlifeParaDevs.Services
{
    public class AlunoService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AlunoService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> BuscarTodosAlunos()
        {
            return _usuarioRepository.BuscarUsuarioPorTipo(1);
        }
    }
}