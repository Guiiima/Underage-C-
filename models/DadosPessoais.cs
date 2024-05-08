using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Underage.models
{
       public class DadosPessoais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string NomeResponsavel { get; set; }
        public string EmailResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
    }
}