using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string OrderBy { get; set; }

        public SelectList Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }
        public async Task OnGetAsync()
        {

            IQueryable<string> bookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book;

            var scriptures = from s in _context.Scripture select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }

            if (!string.IsNullOrEmpty(OrderBy))
            {
                switch (OrderBy)
                {
                    case "book":
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;
                    case "date":
                        scriptures = scriptures.OrderBy(s => s.Accessed);
                        break;
                    default:
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;
                }
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }


    }
}

