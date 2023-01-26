using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.DataTransferObjects;
using ToDoListWebApi.Models.Domain;
using ToDoListWebApi.Models.StronglyTypedIds;
using ToDoListWebApi.objectManager;
using ToDoListWebApi.Services.Abstractions;

namespace ToDoListWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ObjectManager _objectManager;

    public ToDoListController(IAuthService authService, ObjectManager objectManager)
    {
        _authService = authService;
        _objectManager = objectManager;
    }

    [HttpPost("GetOwned")]
    public async Task<ActionResult<List<ToDoListObject>>> GetOwned()
    {
        var userinfo = await _authService.GetInfo(Request.Cookies);
        var username = userinfo.Username;
        var objects = _objectManager.LoadObjects(username);

        return objects;
    }

    [HttpPost("GetVisible")]
    public async Task<ActionResult<List<ToDoListObject>>> GetVisible()
    {
        var userinfo = await _authService.GetInfo(Request.Cookies);
        var username = userinfo.Username;
        var objects = _objectManager.LoadVisibleObjects(username);

        return objects;
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(ToDoListObject toDoListObject)
    {
        var info = await _authService.GetInfo(Request.Cookies);

        var username = info.Username;
        await _objectManager.Create(username, toDoListObject);

        return new OkResult();
    }

    [HttpPost("Update")]
    public async Task<ActionResult> Update(ToDoListObject toDoListObject)
    {
        var info = await _authService.GetInfo(Request.Cookies);

        await _objectManager.Update(info.Username, toDoListObject);

        return new OkResult();
    }

    [HttpPost("Delete")]
    public async Task<ActionResult> Delete(int deletingListId)
    {
        var info = await _authService.GetInfo(Request.Cookies);

        var username = new Username(info.Username);
        await _objectManager.Delete(deletingListId);

        return new OkResult();
    }
}