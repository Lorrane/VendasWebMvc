namespace VendasWebMvc.Models.ViewModels
{
    public class CadastrarVendedorViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
