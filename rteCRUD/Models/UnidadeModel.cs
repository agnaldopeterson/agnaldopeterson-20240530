using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rteCRUD.Models
{
    public class UnidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        public required string Codigo { get; set; } = string.Empty;

        public required string Nome { get; set; } = string.Empty;

        public required bool Ativo { get; set; } = false;

        public ICollection<ColaboradorModel>? Colaborador { get; set; }

    }
}
