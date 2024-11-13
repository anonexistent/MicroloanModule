namespace Models.Models;

public class MicroloanItem
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }
    public float CurrentSum { get; set; }
    public float GeneralDebt { get; set; }
    public float RateDebt { get; set; }

    //// money.Sum
    //public float Balance { get; set; }

    public virtual Money Money { get; set; }
}
