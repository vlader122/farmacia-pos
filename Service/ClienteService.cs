using DB;
using DB.Models;
using Repository;

namespace Service
{
    public class ClienteService : IService<Cliente>
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }
    }
}
