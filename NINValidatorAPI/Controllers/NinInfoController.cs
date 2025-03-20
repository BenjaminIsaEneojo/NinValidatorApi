using Microsoft.AspNetCore.Mvc;
using NINValidatorAPI.ApiModels.Requests;
using NINValidatorAPI.Models;
using NINValidatorAPI.Services;

namespace NINValidatorAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NinInfoController : ControllerBase
{
    private readonly INinInfoService _ninInfoService;
    private readonly List<NinInfo> _ninInfoList;
    public NinInfoController(INinInfoService ninInfoService)
    {
        _ninInfoService = ninInfoService;
        _ninInfoList = new List<NinInfo>();
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateNinInfoRequest request)
    {
        var result = _ninInfoService.CreateNinInfo(request);
        return Ok(result);
        /*_ninInfoList.Add(result);
        return CreatedAtAction(nameof(GetByNin), new { nin = result.NIN }, result);*/
    }

    [HttpGet("get/{nin}")]
    public IActionResult GetByNin(string nin)
    {
        var result = _ninInfoService.GetByNin(nin);
        if (result == null)
            return NotFound(new { message = "NIN not found" });

        return Ok(result);
    }

    [HttpDelete("delete/{nin}")]
    public IActionResult Delete(string nin)
    {
        var result = _ninInfoService.DeleteByNin(nin);
        _ninInfoList.RemoveAll(n => n.NIN == nin);
        return Ok(new { Success = result });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_ninInfoService.GetAll());
    }
}
