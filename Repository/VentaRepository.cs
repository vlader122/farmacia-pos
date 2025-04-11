using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class VentaRepository : IRepository<Venta>
    {
        private readonly PosFarmaciaContext _context;
        public VentaRepository(PosFarmaciaContext context)
        {
            _context = context;
        }

        public async Task<Venta> Create(Venta entity)
        {
            _context.Ventas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Venta> Delete(int id)
        {
            Venta venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                return venta;
            }
            return null;
        }

        public async Task<(List<Venta>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            IQueryable<Venta> query = _context.Ventas.AsQueryable();
            int totalRegistros = await query.CountAsync();
            List<Venta> ventas = await query
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();
            return (ventas, totalRegistros);
        }

        public async Task<Venta> GetById(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task<Venta> Update(Venta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
