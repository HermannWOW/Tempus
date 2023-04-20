using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tempus.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do cliente")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Digite a data de nascimento do cliente")]
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Decimal RendaFamiliar { get; set; }
    }
}
