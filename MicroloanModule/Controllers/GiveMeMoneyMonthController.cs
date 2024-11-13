using MicroloanModule.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts.Input;
using Models.Contracts.Output;

namespace MicroloanModule.Controllers;

[ApiController]
[Route("microloan/month/")]
public class GiveMeMoneyMonthController : ControllerBase
{
    private GiveMeMoneyMonthService _moneyService { get; set; }

    public GiveMeMoneyMonthController(GiveMeMoneyMonthService giveMeMoney)
    {
        _moneyService = giveMeMoney;
    }

    [HttpPost("createMicroloan")]
    public async Task<IActionResult> CreateMicroloan([FromBody] CreateMicroloanMonth body)
    {
        var microloan = await _moneyService.Create(body.Sum, body.Time, body.Rate);
        if (!microloan.Ok || microloan.Answer is null) return BadRequest(microloan.Errors);

        return Ok(new OutputMicroloanMonth(microloan.Answer));
    }
}
