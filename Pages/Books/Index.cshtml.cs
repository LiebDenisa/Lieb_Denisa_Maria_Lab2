﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lieb_Denisa_Maria_Lab2.Data;
using Lieb_Denisa_Maria_Lab2.Models;

namespace Lieb_Denisa_Maria_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Lieb_Denisa_Maria_Lab2.Data.Lieb_Denisa_Maria_Lab2Context _context;

        public IndexModel(Lieb_Denisa_Maria_Lab2.Data.Lieb_Denisa_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
