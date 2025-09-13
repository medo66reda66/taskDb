using Microsoft.EntityFrameworkCore;

namespace SalesDatabase.Data
{
    internal class DbContext
    {
        internal void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            throw new NotImplementedException();
        }

        internal void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}