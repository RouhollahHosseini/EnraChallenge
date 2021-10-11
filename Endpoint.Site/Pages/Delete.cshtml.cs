using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnraChallenge.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Endpoint.Site.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IBookServices _IbookServices;
        public DeleteModel(IBookServices IbookServices)
        {
            _IbookServices = IbookServices;
        }
        
        public IActionResult OnGet(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            _IbookServices.Delete(Id.Value);
            return RedirectToPage("Index");
        }
      
    }
}
