using ProjetoIntegradorUlifeParaDevs.DTOs;
using ProjetoIntegradorUlifeParaDevs.Repositories;
using System.Collections.Generic;

namespace ProjetoIntegradorUlifeParaDevs.Services
{
    public class ProvaService
    {
        private readonly ProvaRepository _provaRepository;

        public ProvaService(ProvaRepository provaRepository)
        {
            _provaRepository = provaRepository;
        }

        public List<Prova> BuscarTodas()
        {
            return _provaRepository.BuscarTodas();
        }

        public List<Prova> BuscarPorId(int provaId)
        {
            return _provaRepository.BuscarPorId(provaId);
        }

        public void AlterarNota(AlterarNotaRequestDto request)
        {
            _provaRepository.AlterarNota(request);
        }
    }
}