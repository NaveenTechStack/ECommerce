using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Data;
using RazorPageApp.Models;

namespace RazorPageApp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == Category.Id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted Successfully";
            return RedirectToPage("Index");
        }
    }
}
