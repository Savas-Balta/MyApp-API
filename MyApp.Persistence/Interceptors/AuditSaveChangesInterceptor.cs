using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Interceptors
{
    public sealed class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUser;
        public AuditSaveChangesInterceptor(ICurrentUserService currentUser) => _currentUser = currentUser;

        private int? UserId => _currentUser.GetUserId();
        private static DateTime UtcNow => DateTime.UtcNow;

        public override InterceptionResult<int> SavingChanges(DbContextEventData e, InterceptionResult<int> r)
        { 
            Apply(e.Context); 
            return base.SavingChanges(e, r); 
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData e, InterceptionResult<int> r, CancellationToken ct = default)
        { 
            Apply(e.Context); 
            return base.SavingChangesAsync(e, r, ct); 
        }

        private void Apply(DbContext? ctx)
        {
            if (ctx is null) return;

            foreach (var entry in ctx.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = UtcNow;
                        entry.Entity.CreatedBy = UserId;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = UtcNow;
                        entry.Entity.UpdatedBy = UserId;
                        break;
                    case EntityState.Deleted: // soft delete
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = UtcNow;
                        entry.Entity.DeletedBy = UserId;
                        break;
                }
            }
        }
    }
}