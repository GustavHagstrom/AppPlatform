using DataAccessLibrary.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Controllers;
[Route("[controller]")]
[ApiController]
public class SampleMongoEntityController : ControllerBase
{
    private readonly IGenericCrud<SampleMongoEntity> genericCrud;

    public SampleMongoEntityController(IGenericCrud<SampleMongoEntity> genericCrud)
    {
        this.genericCrud = genericCrud;
    }
    // GET: api/<TestController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await genericCrud.GetAllAsync();
            return await Task.FromResult(Ok(result));
        }
        catch (Exception e)
        {
            return await Task.FromResult(Problem(e.Message));
        }
    }

    // GET api/<TestController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var result = await genericCrud.GetAsync(id);
            return await Task.FromResult(Ok(result));
        }
        catch (Exception e)
        {
            return await Task.FromResult(Problem(e.Message));
        }
    }

    // POST api/<TestController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SampleMongoEntity entity)
    {
        try
        {
            await genericCrud.CreatAsync(entity);
            return await Task.FromResult(Ok());
        }
        catch (Exception e)
        {
            return await Task.FromResult(Problem(e.Message));
        }
    }

    // PUT api/<TestController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] SampleMongoEntity entity)
    {
        try
        {
            
            await genericCrud.UpsertAsync(id, entity);
            return await Task.FromResult(Ok());
        }
        catch (Exception e)
        {
            return await Task.FromResult(Problem(e.Message));
        }
    }

    // DELETE api/<TestController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await genericCrud.DeleteAsync(id);
            return await Task.FromResult(Ok());
        }
        catch (Exception e)
        {
            return await Task.FromResult(Problem(e.Message));
        }
    }
}
