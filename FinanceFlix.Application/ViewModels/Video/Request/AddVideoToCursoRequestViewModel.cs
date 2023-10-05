using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Video.Request
{
    public class AddVideoToCursoRequestViewModel
    {

        [Column("ID_VIDEO")]
        [Required]
        public Guid VideoId { get; set; }

        [Column("ID_CURSO")]
        [Required]
        public ICollection<Guid> CursoIds { get; set; }


    }
}
