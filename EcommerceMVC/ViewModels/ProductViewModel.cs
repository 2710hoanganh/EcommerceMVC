namespace EcommerceMVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Picture { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
    }
}
