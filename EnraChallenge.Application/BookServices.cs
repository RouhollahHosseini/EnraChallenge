using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnraChallenge.Application
{
    public class BookServices : IBookServices
    {
        private readonly IDataBaseContext _context;
        public BookServices(IDataBaseContext context)
        {
            _context = context;
        }


        public int Add(BookDto bookDto)
        {
            _context.Books.Add(new Domain.Entities.Book
            {
                ID = bookDto.ID,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Publisher = bookDto.Publisher,
                PublishingYear = bookDto.PublishingYear,
                Cover = bookDto.Cover
            });
            return _context.SaveChanges();
            
        }

      

        public int Delete(long _id)
        {
            _context.Books.Remove(new Domain.Entities.Book
            { ID = _id}
            );
            return _context.SaveChanges();
        }

        public BookDto Edit(BookDto bookDto)
        {
            var entity = _context.Books.Find(bookDto.ID);
            entity.Title = bookDto.Title;
            entity.Author = bookDto.Author;
            entity.Publisher = bookDto.Publisher;
            entity.PublishingYear = bookDto.PublishingYear;
            entity.Cover = bookDto.Cover;
            _context.SaveChanges();
            return bookDto;
        }

        public BookDto Find(long Id)
        {
            var book = _context.Books.Find(Id);
            return new BookDto
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishingYear = book.PublishingYear,
                Cover = book.Cover
            };
        }

        public List<BookDto> List()
        {
            var books = _context.Books.Select(p =>
           new BookDto
           {
               ID = p.ID,
               Title = p.Title,
               Author = p.Author,
               Publisher = p.Publisher,
               PublishingYear = p.PublishingYear,
               Cover = p.Cover

           }).ToList();
            return books;
        }
    }
    public class BookDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishingYear { get; set; }
        public byte[] Cover { get; set; }
        

    }
}
