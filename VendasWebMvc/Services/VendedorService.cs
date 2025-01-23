using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class VendedorService(VendasWebMvcContext contexto)
    {
        private readonly VendasWebMvcContext _contexto = contexto;

        public async Task<List<Vendedor>> BuscaTudo()
        {
            return await _contexto.Vendedor.ToListAsync();

        }

        public async Task<Vendedor> BuscaPorId(int id)
        {
            return await _contexto.Vendedor.FindAsync(id);//Include(x => x.Departamento).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Adicionar(Vendedor vendedor)
        {
            await _contexto.Vendedor.AddAsync(vendedor);
            await _contexto.SaveChangesAsync();
        }

        public async Task Editar(Vendedor vendedor)
        {
            _contexto.Update(vendedor);
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(Vendedor vendedor)
        {
            try
            {
                _contexto.Vendedor.Remove(vendedor);
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateException e) {
                throw new DbUpdateException ("Não é possível excluir Vendedor, pois o mesmo possui vendas cadastradas");
            }
        }
    }
}
