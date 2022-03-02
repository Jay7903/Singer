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
    public class IndexModel : PageModel
    {
        private readonly RazorPagessingersContext _context;

        public IndexModel(RazorPagessingersContext context)
        {
            _context = context;
        }

        public IList<singers> singers { get;set; }

        public async Task OnGetAsync()
        {
            singers = await _context.singers.ToListAsync();
        }
    }
}
