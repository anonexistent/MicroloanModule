namespace Models.Models;

public class Money
{
    public Guid Id { get; set; }

    public float Sum { get; set; }
    public uint Time { get; set; }
    public float Rate { get; set; }

    public Guid MoneyId { get; set; }

    public virtual List<MicroloanItem> Items { get; set; }
}
