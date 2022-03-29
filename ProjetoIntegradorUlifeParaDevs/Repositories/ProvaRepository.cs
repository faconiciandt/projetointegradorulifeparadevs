using ProjetoIntegradorUlifeParaDevs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegradorUlifeParaDevs.Repositories
{
    public class ProvaRepository
    {
        private EscolaContext _context;

        public ProvaRepository()
        {
            _context = new EscolaContext();
        }

        public List<Prova> BuscarTodas()
        {
            return _context.Provas.ToList();
        }

        public List<Prova> BuscarPorId(int provaId)
        {
            return _context.Provas
                .Where(p => p.ProvaID == provaId)
                .ToList();
        }

        public void AlterarNota(AlterarNotaRequestDto request)
        {
            var prova = _context.ProvaAlunoes
                .FirstOrDefault(p => p.ProvaID == request.ProvaId && p.UsuarioID == request.AlunoId);

            if (prova != null)
                throw new Exception("Prova não encontrada.");

            prova.Nota = request.ValorNota;

            _context.SaveChanges();
        }
    }
}