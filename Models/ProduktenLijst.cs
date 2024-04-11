namespace The_Bread_Pit.Models
{
    internal class ProduktenLijst
    {
        public List<Produkt>? Produkten { get; set; }
        public List<Categorie>? Categorien { get; set; }
        public string? SelectedCategory { get; set; }

        public string? ActiveCategory(string NaamCategory) => NaamCategory == SelectedCategory ? "active" : "";
    }
}