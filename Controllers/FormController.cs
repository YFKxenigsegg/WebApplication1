using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]/[action]")]
public class FormController(IService service) : Controller
{
    private readonly IService _service = service;

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var form = await _service.Get();
        return View(form);
    }

    [HttpPost]
    public async Task<ActionResult> Update(Form form)
    {
        await _service.Update(form);
        return Ok();

    }

    [HttpPost]
    public async Task<ActionResult> Create()
    {
        await _service.Create();
        return Ok();
    }
}
