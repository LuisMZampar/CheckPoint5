using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? DeletarDados(int id);
        VendedorEntity? EditarDados(VendedorEntity entity);
        VendedorEntity? ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? SalvarDados(VendedorEntity entity);
    }
}
