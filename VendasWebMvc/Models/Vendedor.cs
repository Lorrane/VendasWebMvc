using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVendas(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }

        public void ExcluirVendas(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotaldeVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(rv => rv.Data >= inicio && rv.Data <= fim).Sum(rv => rv.Valor);
        }
    }
}