namespace EcommerceMVC.ViewModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Image { get; set; } = null!;
        public double? Price { get; set; } 
        public int Quantity { get; set; }
        public double? Total {  get; set; }  
    }
}
