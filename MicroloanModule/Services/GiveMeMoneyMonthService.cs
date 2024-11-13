using ApiLibrary;
using DatabaseCore;
using Models.Models;

namespace MicroloanModule.Services;

public class GiveMeMoneyMonthService
{
    public MicroloanDbContext _db { get; set; }

    public GiveMeMoneyMonthService(MicroloanDbContext db)
    {
        _db = db;
    }

    public async Task<ServiceAnswer<Money>> Create(float sum, uint time, float rate)
    {
        var errors = new List<object>();

        if(sum <= 0)
        {
            errors.Add(
                new ServiceFieldError(new[] { "sum" }, 
                "Сумма займа обязана быть не отрацательной!")
            );
        }

        if(time <= 0)
        {
            errors.Add(
                new ServiceFieldError(new[] { "time" }, 
                "Срок займа обязана быть не отрацательной!")
            );
        }

        if(rate <= 0)
        {
            errors.Add(
                new ServiceFieldError(new[] { "rate" }, 
                "Процент займа обязана быть не отрацательной!")
            );
        }

        if (errors.Count > 0)
        {
            return new ServiceAnswer<Money>(false, null) { Errors = errors };
        }

        Money money = new Money()
        {
            Sum = sum,
            Time = time,
            Rate = rate,
        };

        _db.Moneis.Add(money);
        await _db.SaveChangesAsync();

        return new ServiceAnswer<Money>(true, money);
    }

    public async Task<ServiceAnswer<ICollection<MicroloanItem>>> GetList()
    {

    }
}
