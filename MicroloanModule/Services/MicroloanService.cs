using ApiLibrary;
using DatabaseCore;
using Models.Models;

namespace MicroloanModule.Services;

public class MicroloanService
{
    public MicroloanDbContext _db { get; set; }
    public GiveMeMoneyMonthService _moneyService { get; set; }

    public MicroloanService(MicroloanDbContext db, GiveMeMoneyMonthService moneyService)
    {
        _db = db;
        _moneyService = moneyService;
    }

    public async Task<ServiceAnswer<ICollection<MicroloanItem>>> GetList(string moneyId)
    {
        if (!Guid.TryParse(moneyId, out var moneyGuid))
        {
            return new ServiceAnswer<ICollection<MicroloanItem>>(false, null)
            {
                Errors = new[]
                {
                    new ServiceFieldError(new[] { "moneyId" }, "moneyId не соответсвует формату. (uuid4)"),
                }
            };
        }

        var money = await _moneyService.Get(moneyGuid);
        
        if(money.Answer is null)
        {
            return new ServiceAnswer<ICollection<MicroloanItem>>(false, null)
            {
                Errors = new[]
                {
                    new ServiceFieldError(new[] { "" }, "Налогоплательщик не найден."),
                }
            };
        }

        var temp = money.Answer.Sum;
        var moneyItems = new List<MicroloanItem>();

        if(money.Answer.Items.Count == 0)
        {
            for (int x = 0; x < money.Answer.Time; x++)
            {
                var currentPay = money.Answer.Sum / money.Answer.Time + ((money.Answer.Sum * money.Answer.Rate) * (money.Answer.Time / 12));

                var i = money.Answer.Rate / 12;
                var n = money.Answer.Time;
                var k = (i*(Math.Pow(1+i, n)))/(Math.Pow(1+i, n)-1);

                var a = k * money.Answer.Sum;

                var pn = (temp - a * x) * i;

                moneyItems.Add(
                    new MicroloanItem()
                    {
                        Id = Guid.NewGuid(),
                        Date = money.Answer.CreateTime.AddMonths(x + 1),
                        CurrentSum = (float)a,
                        RateDebt = (float)pn,
                        GeneralDebt = (float)(a - pn),
                    }
                );
            }

            return new ServiceAnswer<ICollection<MicroloanItem>>(true, moneyItems);
        }

        return new ServiceAnswer<ICollection<MicroloanItem>>(true, money.Answer.Items);
    }
}
