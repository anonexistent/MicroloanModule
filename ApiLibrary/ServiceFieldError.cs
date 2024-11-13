namespace ApiLibrary;

public record ServiceFieldError(ICollection<string> Fields, string Message);
