#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagessingers.Models;

namespace RazorPagessingers.Pages_singers
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagessingersContext _context;

        public CreateModel(RazorPagessingersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public singers singers { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.singers.Add(singers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
