using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WordSaver.Business.Data
{
    public class WordDBContext : DbContext
    {
        public WordDBContext()
        {
            Configuration.AutoDetectChangesEnabled = false;

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WordDBContext>());
        }

        public DbSet<Word> Words { get; set; }
       
    }
}
