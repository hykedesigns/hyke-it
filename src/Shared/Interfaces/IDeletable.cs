namespace HykeIt.Interfaces;

public interface IDeletable
{
    int DeletedById { get; set; }
    DateTime? DeletedDate { get; set; }
    bool IsDeleted { get; set; }
}
