using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = DateTime.Now;
        }

        //public Guid CreatedBy { get; set; }

    }
}
