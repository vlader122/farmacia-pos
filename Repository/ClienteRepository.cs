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
        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
