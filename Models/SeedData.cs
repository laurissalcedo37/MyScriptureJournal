using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                       
                        Accessed = DateTime.Parse("2019-1-1"),
                        Book = "Proverbs",
                        Chapter = 31,
                        Verse = 10,
                        Notes = "A very good scripture"
                    },

                    new Scripture
                    {
                        
                        Accessed = DateTime.Parse("2019-2-1"),
                        Book = "Matthew",
                        Chapter = 25,
                        Verse = 40,
                        Notes = " We need to serve our fellow men. "
                    },

                    new Scripture
                    {
                       
                        Accessed = DateTime.Parse("2019-3-1"),
                        Book = "Alma",
                        Chapter = 37,
                        Verse = 35,
                        Notes = "Learn while we are young"
                    },

                  new Scripture
                  {
                     
                      Accessed = DateTime.Parse("2019-4-1"),
                      Book = "N/A",
                      Chapter = 137,
                      Verse = 9,
                      Notes = "Judge by works"
                  },
                  new Scripture
                  {
                      
                      Accessed = DateTime.Parse("2019-5-1"),
                      Book = "Articles of Faith",
                      Chapter = 1,
                      Verse = 13,
                      Notes = "We believe"
                  }
                );
                context.SaveChanges();
            }
        }
    }
}

