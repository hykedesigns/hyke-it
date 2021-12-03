namespace HykeIt.Models.Install;

public class Installation
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public Alias? Alias { get; set; }
}
