namespace OiBobaLoja.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Print>? Prints { get; set; }
    }
}
