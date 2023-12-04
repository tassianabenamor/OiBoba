namespace OiBobaLoja.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Print> Prints { get; set; }
    }
}