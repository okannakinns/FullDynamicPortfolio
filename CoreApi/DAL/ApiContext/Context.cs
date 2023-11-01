using CoreApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
    optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=OKAN-LAPTOP\\OKANAKIN; Initial Catalog=CoreApiTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
