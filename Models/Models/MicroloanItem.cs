namespace Models.Models;

public class MicroloanItem
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }
    //total in period
    public float CurrentSum { get; set; }
    //body
    public float GeneralDebt { get; set; }
    //%
    public float RateDebt { get; set; }

    //// money.Sum
    //public float Balance { get; set; }

    public virtual Money Money { get; set; }
}
