using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnraChallenge.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Endpoint.Site.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IBookServices _IbookServices;
        [BindProperty]
        public  BookDto bookDto { get; set; }

        [BindProperty]
        public IFormFile upDateFile { get; set; }
        public UpdateModel(IBookServices IbookServices)
        {
            _IbookServices = IbookServices;
        }
        public IActionResult OnGet(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            bookDto= _IbookServices.Find(Id.Value);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (upDateFile != null)
            {


                using (var target = new MemoryStream())
                {
                    upDateFile.CopyToAsync(target);

                    bookDto.Cover = target.ToArray();
                }
            }
            else
            {
                bookDto.Cover = _IbookServices.Find(bookDto.ID).Cover;
            }
            _IbookServices.Edit(bookDto);
            return RedirectToPage("Index");
        }
    }
}
