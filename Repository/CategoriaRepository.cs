using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly PosFarmaciaContext _context;
        public CategoriaRepository(PosFarmaciaContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Categoria> Delete(int id)
        {
            Categoria categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }
            return null;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> Update(Categoria entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
