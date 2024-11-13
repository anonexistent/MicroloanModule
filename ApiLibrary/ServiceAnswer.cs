namespace ApiLibrary;

public record ServiceAnswer<TAnswer>(bool Ok, TAnswer? Answer)
{
    public ICollection<object> Errors { get; set; } = Array.Empty<object>();
}
