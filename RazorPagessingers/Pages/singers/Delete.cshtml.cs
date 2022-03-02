#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

namespace RazorPagessingers.Pages_singers
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagessingersContext _context;

        public DeleteModel(RazorPagessingersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public singers singers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            singers = await _context.singers.FirstOrDefaultAsync(m => m.ID == id);

            if (singers == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            singers = await _context.singers.FindAsync(id);

            if (singers != null)
            {
                _context.singers.Remove(singers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
