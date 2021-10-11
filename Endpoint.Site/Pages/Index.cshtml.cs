using EnraChallenge.Application;
using EnraChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site.Pages
{
    public class IndexModel : PageModel 
    {
        public List<BookDto> books { get; set; } = new List<BookDto>();
        private readonly IBookServices _IbookServices ;

        

        public IndexModel(IBookServices IbookServices)
        {
            _IbookServices = IbookServices;
        }

        public void OnGet()
        {
            books = _IbookServices.List();
            
        }
    }
}
