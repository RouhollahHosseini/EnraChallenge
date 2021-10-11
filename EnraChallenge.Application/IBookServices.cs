using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnraChallenge.Application
{
    public interface IBookServices
    {
        int Add(BookDto  bookDto);
        int Delete(long Id);
        BookDto Find(long Id);
        List<BookDto> List();
        BookDto Edit(BookDto bookDto);
    }
}
