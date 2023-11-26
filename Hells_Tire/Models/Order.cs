namespace Hells_Tire.Models
{
    public class Order
    {
        public long Id { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public DateTime OrderDate { get; set; }

        // Дополнительные поля заказа, если необходимо

        public List<OrderItem> OrderItems { get; set; }
    }
}
