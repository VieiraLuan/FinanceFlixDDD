

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
