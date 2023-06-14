using BulkuWebRazor_Temp.Data;
using BulkuWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkuWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly Applicationdbcontext _db;

        

        public EditModel(Applicationdbcontext db)
        {
            _db = db;
        }




        public Category Category { get; set; }

        public IActionResult OnGet(int id)
        {
            Category = _db.Categories.Find(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingCategory = _db.Categories.Find(Category?.Id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = Category.Name;
            existingCategory.DisplayOrder = Category.DisplayOrder;
            // Update other properties as needed

            _db.SaveChanges();
            TempData["Success"] = "Category Updated Successfully";

            return RedirectToPage("Index");
        }



    }
}
