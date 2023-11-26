using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hells_Tire.Models
{
    public class AppUser : IdentityUser
    {
        public string Deff { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
