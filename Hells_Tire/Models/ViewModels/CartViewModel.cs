namespace Hells_Tire.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }  

        public decimal GrandTotal { get; set; }
    }
}
