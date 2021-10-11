using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnraChallenge.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Endpoint.Site.Pages
{
    public class ShowCoverModel : PageModel
    {
        private readonly IBookServices _IbookServices;
        public BookDto book { get; set; } = new BookDto();
       
        public ShowCoverModel(IBookServices IbookServices)
        {
            _IbookServices = IbookServices;
        }
        public byte[] cover { get; set; }
        public void OnGet(long Id)
        {
           
            book = _IbookServices.Find(Id);
           
            
        }
    }
}
