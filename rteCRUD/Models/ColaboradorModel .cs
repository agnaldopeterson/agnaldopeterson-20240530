using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rteCRUD.Models
{
    public class ColaboradorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public  string Codigo { get; set; } = string.Empty;

        public  string Nome { get; set; } = string.Empty;

        public required UnidadeModel Unidade { get; set; }
      
        public required UsuarioModel Usuario { get; set; }

    }
}
