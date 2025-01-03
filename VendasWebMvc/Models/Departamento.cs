namespace VendasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; } = new List<Vendedor>();

        public Departamento() { }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarVendedor (Vendedor vendedor)
        {
            Vendedor.Add(vendedor);
        }

        public double TotaldeVendas(DateTime inicio, DateTime fim)
        {
            return Vendedor.Sum(vendedor => vendedor.TotaldeVendas (inicio, fim));
        }
    }
}
