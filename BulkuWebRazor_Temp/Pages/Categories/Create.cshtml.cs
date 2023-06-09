using BulkuWebRazor_Temp.Data;
using BulkuWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkuWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly Applicationdbcontext _db;
        
        public Category Category { get; set; }

        public CreateModel(Applicationdbcontext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
            
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
