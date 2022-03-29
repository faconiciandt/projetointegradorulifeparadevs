using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradorUlifeParaDevs.DTOs
{
    public class AlterarNotaRequestDto
    {
        [Required]
        public int ValorNota { get; set; }
        [Required]
        public int ProvaId { get; set; }
        [Required]
        public int AlunoId { get; set; }
    }
}