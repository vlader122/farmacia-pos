using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly PosFarmaciaContext _context;
        public ProductoRepository(PosFarmaciaContext context)
        {
            _context = context;
        }

        public async Task<Producto> Create(Producto entity)
        {
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Producto> Delete(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            return null;
        }

        public async Task<(List<Producto>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            IQueryable<Producto> query = _context.Productos.AsQueryable();
            int totalRegistros = await query.CountAsync();
            List<Producto> productos = await query
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();
            return (productos, totalRegistros);
        }

        public async Task<Producto> GetById(int id)
        {
            return await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
