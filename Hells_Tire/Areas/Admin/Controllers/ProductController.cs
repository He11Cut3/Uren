using Hells_Tire.Infrastructure;
using Hells_Tire.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Hells_Tire.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            return View(await _context.HellsTireProducts.Include(p => p.HellsTireCategory).ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.HellsTireCategories, "HellsTireCategoryID", "HellsTireCategoryName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(HellsTireProduct product)
        {
            ViewBag.Categories = new SelectList(_context.HellsTireCategories, "HellsTireCategoryID", "HellsTireCategoryName", product.HellsTireCategoryID);

            if (ModelState.IsValid)
            {
                product.HellsTireProductSlug = product.HellsTireProductName.ToLower().Replace(" ", "-");

                var slug = await _context.HellsTireProducts.FirstOrDefaultAsync(p => p.HellsTireProductID == product.HellsTireCategoryID);
                // Создайте список для хранения данных изображений
                if (product.ImageFile != null && product.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await product.ImageFile.CopyToAsync(ms);
                        product.HellsTireProductImage = ms.ToArray();
                    }
                }

                _context.HellsTireProducts.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(product);
        }
        public async Task<IActionResult> Edit(long id)
        {
            HellsTireProduct product = await _context.HellsTireProducts.FindAsync(id);
            if (product != null)
            {
                ViewBag.Categories = new SelectList(_context.HellsTireCategories, "HellsTireCategoryID", "HellsTireCategoryName", product.HellsTireCategoryID);

            }

            return View(product);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HellsTireProduct product)
        {
            ViewBag.Categories = new SelectList(_context.HellsTireCategories, "HellsTireCategoryID", "HellsTireCategoryName", product.HellsTireCategoryID);

            if (ModelState.IsValid)
            {
                product.HellsTireProductSlug = product.HellsTireProductName.ToLower().Replace(" ", "-");

                // Если у вас есть какой-то уникальный идентификатор для продукта (например, HellsTireProductID), используйте его
                // В данном примере, я предполагаю, что у продукта есть уникальное поле HellsTireProductID
                var existingProduct = await _context.HellsTireProducts.FirstOrDefaultAsync(p => p.HellsTireProductID == product.HellsTireProductID);

                if (existingProduct != null)
                {
                    // Обновляем существующий продукт с новыми данными
                    existingProduct.HellsTireProductName = product.HellsTireProductName;
                    existingProduct.HellsTireProductPrice = product.HellsTireProductPrice;
                    existingProduct.HellsTireProductDescriptions = product.HellsTireProductDescriptions;
                    existingProduct.HellsTireProductBrand = product.HellsTireProductBrand;
                    existingProduct.HellsTireCategoryID = product.HellsTireCategoryID;
                    existingProduct.HellsTireProductSlug = product.HellsTireProductSlug;
                    existingProduct.HellsTireCategoryID = product.HellsTireCategoryID;
                    // Продолжайте обновлять другие свойства продукта по необходимости

                    // Проверяем, загружено ли новое изображение
                    if (product.ImageFile != null && product.ImageFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await product.ImageFile.CopyToAsync(ms);
                            existingProduct.HellsTireProductImage = ms.ToArray();
                        }
                    }

                    // Обновляем запись в базе данных
                    _context.HellsTireProducts.Update(existingProduct);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            return View(product);
        }
        public async Task<IActionResult> Delete(long id)
        {
            HellsTireProduct product = await _context.HellsTireProducts.FindAsync(id);

            _context.HellsTireProducts.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
