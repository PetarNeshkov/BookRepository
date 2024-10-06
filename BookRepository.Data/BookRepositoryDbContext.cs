using BookRepository.Data.Common;
using BookRepository.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Data
{
    public class BookRepositoryDbContext(DbContextOptions<BookRepositoryDbContext> options)
        : DbContext(options)
    {
        public DbSet<Author> Authors { get; init; }

        public DbSet<Book> Books { get; init; }

        public DbSet<BookChange> BookChanges { get; init; }

        public override int SaveChanges()
        {
            ApplyAuditInfo();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ApplyAuditInfo();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            var changedEntries = ChangeTracker
             .Entries()
             .Where(e => e is { Entity: IAuditInfo, State: EntityState.Added or EntityState.Modified });

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
