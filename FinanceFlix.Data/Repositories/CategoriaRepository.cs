using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;


namespace FinanceFlix.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;  

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }


        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetById(Guid id)
        {
            return _context.Categorias.Find(id);
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
    }
}
