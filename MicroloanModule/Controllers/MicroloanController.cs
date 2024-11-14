using MicroloanModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroloanModule.Controllers;

[ApiController]
[Route("microloan/item/")]
public class MicroloanController : ControllerBase
{
    private MicroloanService _service { get; set; }

    public MicroloanController(MicroloanService service)
    {
        _service = service;
    }

    [HttpPost("getList")]
    public async Task<IActionResult> GetList(string moneyId)
    {
        var list = await _service.GetList(moneyId);
        if (list.Answer is null || !list.Ok) return BadRequest(list.Errors);

        return Ok(list);
    }
}
