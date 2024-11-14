namespace Models.Models;

public class Money
{
    public Guid Id { get; set; }

    public float Sum { get; set; }
    public uint Time { get; set; }
    public float Rate { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual ICollection<MicroloanItem> Items { get; set; } = new List<MicroloanItem>();
}
