using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMvcContext _contexto;


        public DepartamentoService (VendasWebMvcContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Departamento>> BuscaTudo()
        {
            return await _contexto.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Departamento> BuscarPorId(int? id)
        {
            return await _contexto.Departamento.FindAsync(id);
            
        }
    }
}
