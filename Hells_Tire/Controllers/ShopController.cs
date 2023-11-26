using Hells_Tire.Infrastructure;
using Hells_Tire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hells_Tire.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;

        }

        public async Task<HellsTireProduct> LoadData(long id)
        {
            return await _context.HellsTireProducts.FirstOrDefaultAsync(p=>p.HellsTireProductID == id);
        }


        public async Task<IActionResult> Index(long? categoryId)
        {
            var categories = _context.HellsTireCategories.ToList();
            IQueryable<HellsTireProduct> productsQuery = _context.HellsTireProducts;

            // Фильтрация товаров по категории, если categoryId указан
            if (categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.HellsTireCategoryID == categoryId.Value);
            }

            var products = await productsQuery.ToListAsync();

            // Здесь вы можете передать данные в представление, включая categoryId
            return View(products.ToList());
        }

        public async Task<IActionResult> Details(long id)
        {

            var product = await LoadData(id);

            if (product == null)
            {
                return NotFound(); // Если продукт с указанным id не найден, возвращаем HTTP 404
            }

            return View(product);
        }
    }
}
