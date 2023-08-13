namespace ApiTabelaFipe.Domain.Models
{
    public class Marca
    {
        public int Codigo { get; set; }

        public string? Nome { get; set; }

        public virtual List<Modelo>? Modelos { get; set; }
    }
}
