using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Data;
using RazorPageApp.Models;

namespace RazorPageApp.Pages.Categories
{
    [BindProperties]// Bind the property So post will work
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
 
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["Success"] = "Category created Successfully";
            return RedirectToPage("Index");
        }
    }
}
