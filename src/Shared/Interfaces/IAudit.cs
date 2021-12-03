namespace HykeIt.Interfaces;

public interface IAudit
{
    int CreatedById { get; set; }
    DateTime CreateDate { get; set; }
    int UpdatedById { get; set; }
    DateTime UpdateDate { get; set; }
}
