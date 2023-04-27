namespace StayFit.Models
{
    public class Instrutor
    {
        public Instrutor() { 
            Clientes = new List<Cliente>();        
        }
        public int InstrutorId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public IEnumerable<Cliente>? Clientes { get; set; }
    }
}
