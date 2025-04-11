using DB;
using DB.Models;
using Repository;

namespace Service
{
    public class ProductoService : IService<Producto>
    {
        private readonly ProductoRepository _productoRepository;
        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<Producto> Create(Producto entity)
        {
            return await _productoRepository.Create(entity);
        }

        public async Task<Producto> Delete(int id)
        {
            return await _productoRepository.Delete(id);
        }

        public async Task<(List<Producto>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return await _productoRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Producto> GetById(int id)
        {
            return await _productoRepository.GetById(id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            return await _productoRepository.Update(entity);
        }
    }
}
