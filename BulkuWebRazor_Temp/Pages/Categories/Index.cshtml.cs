using BulkuWebRazor_Temp.Data;
using BulkuWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace BulkuWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Applicationdbcontext _db;

        public List<Category> CategoryList { get; set; }

        public IndexModel(Applicationdbcontext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
