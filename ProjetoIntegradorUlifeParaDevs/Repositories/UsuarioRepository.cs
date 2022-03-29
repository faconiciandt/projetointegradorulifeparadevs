using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegradorUlifeParaDevs.Repositories
{
    public class UsuarioRepository
    {
        private EscolaContext _context;

        public UsuarioRepository()
        {
            _context = new EscolaContext();
        }

        public Usuario ValidaUsuario(string username, string password)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == username.ToLower()
                                && x.Senha == password).FirstOrDefault();
        }
    }
}