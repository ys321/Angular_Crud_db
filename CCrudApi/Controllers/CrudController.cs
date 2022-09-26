    // using Microsoft.AspNetCore.Mvc;
    // using CCrudApi.Data;
     
    // namespace CCrudApi.Controllers;
     
    // [ApiController]
    // [Route("[controller]")]
    // public class CrudController: ControllerBase
    // {
    //     private readonly MyWorldDbContext _myWorldDbContext;
    //     public CrudController(MyWorldDbContext myWorldDbContext)
    //     {
    //         _myWorldDbContext = myWorldDbContext;
    //     }
    // }

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCrudApi.Data;

namespace CCrudApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CrudController : ControllerBase
{
    private readonly MyWorldDbContext _myWorldDbContext;
    public CrudController(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cruds = await _myWorldDbContext.Cruds.ToListAsync();
        return Ok(cruds);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CCrudApi.Data.Entities.Cruds payload)
    {
        _myWorldDbContext.Cruds.Add(payload);
        await _myWorldDbContext.SaveChangesAsync();
        return Ok(payload);
    }

    [HttpPut]
    public async Task<IActionResult> Put(CCrudApi.Data.Entities.Cruds payload)
    {
        _myWorldDbContext.Cruds.Update(payload);
        await _myWorldDbContext.SaveChangesAsync();
        return Ok(payload);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var crudToDelete = await _myWorldDbContext.Cruds.FindAsync(id);
        if (crudToDelete == null)
        {
            return NotFound();
        }
        _myWorldDbContext.Cruds.Remove(crudToDelete);
        await _myWorldDbContext.SaveChangesAsync();
        return Ok();
    }
}