using FeiraMissionaria.CrossCutting.Enums;
using FeiraMissionaria.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace FeiraMissionaria.Infrastructure.Audits;
public class Audit : IEntity
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Type { get; set; }
    public string TableName { get; set; }
    public DateTime DateTime { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public string AffectedColumns { get; set; }
    public string PrimaryKey { get; set; }
}

public class AuditEntry
{
    public AuditEntry(EntityEntry entry)
    {
        Entry = entry;
    }
    public EntityEntry Entry { get; }
    public string UserId { get; set; }
    public string TableName { get; set; }
    public Dictionary<string, object> KeyValues { get; } = new();
    public Dictionary<string, object> OldValues { get; } = new();
    public Dictionary<string, object> NewValues { get; } = new();
    public AuditType AuditType { get; set; }
    public List<string> ChangedColumns { get; } = new List<string>();
    public Audit ToAudit()
    {
        var audit = new Audit();
        audit.Id = Guid.NewGuid();
        audit.UserId = UserId;
        audit.Type = AuditType.ToString();
        audit.TableName = TableName;
        audit.DateTime = DateTime.Now;
        audit.PrimaryKey = JsonSerializer.Serialize(KeyValues);
        audit.OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues);
        audit.NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues);
        audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonSerializer.Serialize(ChangedColumns);
        return audit;
    }
}
