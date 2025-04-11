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

        public async Task<Cliente> Create(Cliente entity)
        {
            return await _clienteRepository.Create(entity);
        }

        public async Task<Cliente> Delete(int id)
        {
            return await _clienteRepository.Delete(id);
        }

        public async Task<(List<Cliente>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return await _clienteRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            return await _clienteRepository.Update(entity);
        }
    }
}
