namespace ApiTabelaFipe.Domain.Models
{
    public class Modelo
    {
        public long Codigo { get; set; }

        public string? Nome { get; set; }

        public virtual int MarcaCodigo { get; set; }

        public virtual Marca? Marca { get; set; }
    }
}
