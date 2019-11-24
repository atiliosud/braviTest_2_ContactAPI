using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.Model
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Skype { get; set; }
        public string Telefone { get; set; }
        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
    }
}
