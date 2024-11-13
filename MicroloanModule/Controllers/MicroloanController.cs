using MicroloanModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroloanModule.Controllers;

[ApiController]
[Route("microloan/item/")]
public class MicroloanController
{
    private MicroloanService _service { get; set; }

    public MicroloanController(MicroloanService service)
    {
        _service = service;
    }

    [HttpPost("getList")]
    public async Task<IActionResult> GetList(string moneyId)
    {

    }
}
