using FeiraMissionaria.CrossCutting.Enums;
using FeiraMissionaria.Infrastructure.Audits;
using FeiraMissionaria.Persistence.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FeiraMissionaria.Persistence.Contexts;
public class FeiraMissionariaDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IHttpContextAccessor _httpContext;


    public FeiraMissionariaDbContext(IHttpContextAccessor httpContext) : base()
    {
        _httpContext = httpContext;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine);
#endif
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(FeiraMissionariaDbContext).Assembly);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        var handler = new ContextEventHandler();
        var auditList = OnBeforeSaveChanges();

        handler.InvokeSavingChanges(this);

        var result = base.SaveChanges(acceptAllChangesOnSuccess);
        handler.InvokeSavedChanges(this);

        return result;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var handler = new ContextEventHandler();
        var auditList = OnBeforeSaveChanges();

        handler.InvokeSavingChanges(this);

        var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        handler.InvokeSavedChanges(this);

        return result;
    }


    private List<AuditEntry> OnBeforeSaveChanges()
    {
        var auditEntries = new List<AuditEntry>();
        try
        {
            ChangeTracker.DetectChanges();
            var login = _httpContext?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State is EntityState.Detached or EntityState.Unchanged || string.IsNullOrEmpty(login))
                    continue;

                var auditEntry = new AuditEntry(entry) { TableName = entry.Entity.GetType().Name, UserId = login };
                auditEntries.Add(auditEntry);

                var properties = entry.Entity.GetType().GetProperties().Where(p => p.PropertyType == typeof(string) && p.CanRead && p.CanWrite);

                foreach (var property in properties)
                {
                    if (string.IsNullOrWhiteSpace(property.GetValue(entry.Entity, null) as string))
                        property.SetValue(entry.Entity, null, null);
                }

                foreach (var property in entry.Properties)
                {
                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }

                    //await Audits.AddAsync(auditEntry.ToAudit());
                }
            }
        }
        catch (Exception ex)
        {
            //Log.Error(ex, "Erro ao salvar a auditoria");
        }

        return auditEntries;
    }
}
