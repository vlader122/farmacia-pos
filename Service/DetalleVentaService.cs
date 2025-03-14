using DB;
using DB.Models;
using Repository;

namespace Service
{
    public class DetalleVentaService : IService<DetalleVenta>
    {
        private readonly DetalleVentaRepository _detalleVentaRepository;
        public DetalleVentaService(DetalleVentaRepository detalleVentaRepository)
        {
            _detalleVentaRepository = detalleVentaRepository;
        }

        public async Task<DetalleVenta> Create(DetalleVenta entity)
        {
            return await _detalleVentaRepository.Create(entity);
        }

        public async Task<DetalleVenta> Delete(int id)
        {
            return await _detalleVentaRepository.Delete(id);
        }

        public async Task<List<DetalleVenta>> GetAll()
        {
            return await _detalleVentaRepository.GetAll();
        }

        public async Task<DetalleVenta> GetById(int id)
        {
            return await _detalleVentaRepository.GetById(id);
        }

        public async Task<DetalleVenta> Update(DetalleVenta entity)
        {
            return await _detalleVentaRepository.Update(entity);
        }
    }
}
