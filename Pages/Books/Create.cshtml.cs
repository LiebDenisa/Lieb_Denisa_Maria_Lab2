﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lieb_Denisa_Maria_Lab2.Data;
using Lieb_Denisa_Maria_Lab2.Models;

namespace Lieb_Denisa_Maria_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Lieb_Denisa_Maria_Lab2.Data.Lieb_Denisa_Maria_Lab2Context _context;

        public CreateModel(Lieb_Denisa_Maria_Lab2.Data.Lieb_Denisa_Maria_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}