using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity DeletarDados(int id)
        {
            var entity = _context.Fornecedor.Find(id);
            if (entity is not null)
            {
                _context.Fornecedor.Remove(entity);
                _context.SaveChanges(); 

                return entity;
            }
            return null;
        }


        public FornecedorEntity EditarDados(FornecedorEntity entity)
        {
            var fornecedor = _context.Fornecedor.Find(entity.Id);

            if (fornecedor is not null)
            {
                fornecedor.Nome = entity.Nome;
                fornecedor.Cnpj = entity.Cnpj;
                fornecedor.Endereco = entity.Endereco;
                fornecedor.Telefone = entity.Telefone;
                fornecedor.Email = entity.Email;
                fornecedor.CriadoEm = entity.CriadoEm;

                _context.Fornecedor.Update(fornecedor);
                _context.SaveChanges();

                return entity;
            }
            return null;
        }

        public FornecedorEntity ObterPorId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if(fornecedor is not null)
            {
                return fornecedor;
            }

            return null;
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            var fornecedor = _context.Fornecedor.ToList();

            return fornecedor;
        }

        public FornecedorEntity SalvarDados(FornecedorEntity entity)
        {
            _context.Fornecedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
