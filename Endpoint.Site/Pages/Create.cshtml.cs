using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnraChallenge.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Endpoint.Site.Pages
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public BookDto bookDto { get; set; } = new BookDto();
        [BindProperty]
        public IFormFile uploadFile { get; set ; } 
        private readonly IBookServices _bookServices;
       

        public CreateModel(IBookServices bookServices)
        {
            _bookServices = bookServices;



        }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (uploadFile != null)
            {

            
            using (var target = new MemoryStream())
            {
                uploadFile.CopyToAsync(target);

                bookDto.Cover = target.ToArray();
            }
            }
            _bookServices.Add(bookDto);

            return RedirectToPage("Index");




        }

    }
}
