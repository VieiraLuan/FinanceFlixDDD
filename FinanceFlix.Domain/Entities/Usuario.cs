using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [NotMapped]
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Column("ID_USUARIO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }

        [Column("NOME_USUARIO")]
        [Required]
        [StringLength(80)]
        public string Nome { get; private set; }
    }
}
