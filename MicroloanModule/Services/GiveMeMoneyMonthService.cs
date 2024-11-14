using ApiLibrary;
using DatabaseCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;

namespace MicroloanModule.Services;

public class GiveMeMoneyMonthService
{
    public MicroloanDbContext _db { get; set; }

    public GiveMeMoneyMonthService(MicroloanDbContext db)
    {
        _db = db;
    }

    public async Task<ServiceAnswer<Money>> Get(string id)
    {
        if(!Guid.TryParse(id, out var guid))
        {
            return new ServiceAnswer<Money>(false, null)
            {
                Errors = new[]
                {
                    new ServiceFieldError(new[] { "id" }, "id не соответсвует формату. (uuid4)"),
                }
            };
        }

        return await Get(guid);
    }

    public async Task<ServiceAnswer<Money>> Get(Guid id)
    {
        var result = await _db.Moneis.SingleOrDefaultAsync(x => x.Id == id);

        return new ServiceAnswer<Money>(true, result);
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
            Rate = rate / 100,

            CreateTime = DateTime.UtcNow,
        };

        _db.Moneis.Add(money);
        await _db.SaveChangesAsync();

        return new ServiceAnswer<Money>(true, money);
    }

}
