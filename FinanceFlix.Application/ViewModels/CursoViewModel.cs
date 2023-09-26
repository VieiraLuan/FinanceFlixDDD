using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels
{
    public class CursoViewModel
    {

        public int Id { get;  set; }

        [Column("NOME_CURSO")]
        [Required]
        [StringLength(80)]
        public string Nome { get;  set; }

        [Column("DESC_CURSO")]
        [Required]
        [StringLength(120)]
        public string Descricao { get;  set; }

        [Column("IMG_CURSO")]
        public byte[]? ImagemUrl { get;  set; }

        public int CategoriaId { get;  set; }



    }
}
