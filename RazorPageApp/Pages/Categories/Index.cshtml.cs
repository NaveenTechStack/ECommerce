using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Data;
using RazorPageApp.Models;

namespace RazorPageApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}
