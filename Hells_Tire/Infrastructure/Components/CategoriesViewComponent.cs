using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hells_Tire.Infrastructure.Components
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly DataContext _context;

        public CategoriesViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.HellsTireCategories.ToListAsync());
    }
}
