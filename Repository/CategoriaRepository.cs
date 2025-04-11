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

        public async Task<(List<Categoria>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            IQueryable<Categoria> query = _context.Categorias.AsQueryable();
            int totalRegistros = await query.CountAsync();
            List<Categoria> categorias = await query
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();
            return (categorias, totalRegistros);
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
