using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly PosFarmaciaContext _context;
        public ClienteRepository(PosFarmaciaContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Cliente> Delete(int id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            return null;
        }

        public async Task<(List<Cliente>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            IQueryable<Cliente> query = _context.Clientes.AsQueryable();
            int totalRegistros = await query.CountAsync();
            List<Cliente> clientes = await query
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();
            return (clientes, totalRegistros);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
