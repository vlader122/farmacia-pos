using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DetalleVentaRepository : IRepository<DetalleVenta>
    {
        private readonly PosFarmaciaContext _context;
        public DetalleVentaRepository(PosFarmaciaContext context)
        {
            _context = context;
        }

        public async Task<DetalleVenta> Create(DetalleVenta entity)
        {
            _context.DetalleVentas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DetalleVenta> Delete(int id)
        {
            DetalleVenta detalleVenta = await _context.DetalleVentas.FindAsync(id);
            if (detalleVenta != null)
            {
                _context.DetalleVentas.Remove(detalleVenta);
                await _context.SaveChangesAsync();
                return detalleVenta;
            }
            return null;
        }

        public async Task<List<DetalleVenta>> GetAll()
        {
            return await _context.DetalleVentas.ToListAsync();
        }

        public async Task<DetalleVenta> GetById(int id)
        {
            return await _context.DetalleVentas.FindAsync(id);
        }

        public async Task<DetalleVenta> Update(DetalleVenta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
