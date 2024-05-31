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

        [ForeignKey("UnidadeId")]
        public required UnidadeModel Unidade { get; set; }
        public int UnidadeId { get; set; }

        [ForeignKey("UsuarioId")]
        public required UsuarioModel Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}
