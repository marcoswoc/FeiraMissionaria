﻿using FeiraMissionaria.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FeiraMissionaria.Persistence.Events;
public static class AuditEvent
{
    public static void SavingChanges(object sender, EventArgs eventArgs = null)
    {
        if (!(sender is DbContext context)) return;

        foreach (var entrie in context.ChangeTracker.Entries())
        {
            if (!(entrie.Entity is IAuditable auditable))
                continue;

            if (entrie.State == EntityState.Added || entrie.State == EntityState.Detached)
            {
                auditable.CreatedAt = DateTime.Now;
            }
            else if (entrie.State == EntityState.Modified)
            {
                auditable.UpdatedAt = DateTime.Now;
            }
            else if (entrie.State == EntityState.Deleted)
            {
                auditable.DeletedAt = DateTime.Now;
                entrie.State = EntityState.Modified;
            }
        }
    }

    public static void SavedChanges(object sender, EventArgs? eventArgs = null) { }
}
