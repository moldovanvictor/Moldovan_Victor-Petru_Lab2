﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moldovan_Victor_Petru_Lab2.Data;
using Moldovan_Victor_Petru_Lab2.Models;
using Moldovan_Victor_Petru_Lab2.Models.ViewModels;

namespace Moldovan_Victor_Petru_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Moldovan_Victor_Petru_Lab2.Data.Moldovan_Victor_Petru_Lab2Context _context;

        public IndexModel(Moldovan_Victor_Petru_Lab2.Data.Moldovan_Victor_Petru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            if (_context.Category != null)
            {
                CategoryData = new CategoryIndexData();
                CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                    .ThenInclude(d => d.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();
                if (id != null)
                {
                    CategoryID = id.Value;
                    Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                    CategoryData.Books=category.BookCategories.Select(b => b.Book);
                }
            }
        }
    }
}
