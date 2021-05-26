using Microsoft.EntityFrameworkCore;

namespace Salvo.Models
{
    public class SalvoContext : DbContext
    {
        public SalvoContext(DbContextOptions<SalvoContext> options) : base(options)
        {
        }

        //Items created in Model. They will register here.
        public DbSet<SalvoItem> SalvoItems { get; set; }
    }
}
