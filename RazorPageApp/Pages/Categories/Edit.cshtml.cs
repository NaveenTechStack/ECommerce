using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Data;
using RazorPageApp.Models;

namespace RazorPageApp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id !=null && id !=0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["Success"] = "Category updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

