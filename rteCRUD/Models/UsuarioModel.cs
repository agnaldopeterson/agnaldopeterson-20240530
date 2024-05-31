using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rteCRUD.Models
{
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; } = 0;

        public required string Login { get; set; } = string.Empty;

        public required string Senha { get; set; } = string.Empty;
        
        public required bool Ativo { get; set; } = false;
        public ICollection<ColaboradorModel> Colaboradores { get; set; } = new List<ColaboradorModel>();

    }
}
