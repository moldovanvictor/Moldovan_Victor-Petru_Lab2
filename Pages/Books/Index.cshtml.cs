using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moldovan_Victor_Petru_Lab2.Data;
using Moldovan_Victor_Petru_Lab2.Models;

namespace Moldovan_Victor_Petru_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Moldovan_Victor_Petru_Lab2.Data.Moldovan_Victor_Petru_Lab2Context _context;

        public IndexModel(Moldovan_Victor_Petru_Lab2.Data.Moldovan_Victor_Petru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public IList<Author> Authors { get; set; } = default!;
        public SelectListItem AuthorsList { get; set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Title)
                    .ToListAsync();
            }

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }

            if (_context.Author != null)
            {
                Authors = await _context.Author.ToListAsync();

                //AuthorsList = Authors.Select(x => new SelectListItem
                //{
                //    Text = x.FirstName,
                //    Value = x.FirstName
                //}).ToList();
            }
        }
    }
}
