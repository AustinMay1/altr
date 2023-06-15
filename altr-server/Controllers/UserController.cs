using altr_server.data;
using Microsoft.AspNetCore.Mvc;
using altr_server.Repositories;

namespace altr_server.Controllers;

[Route(Routes.userBase)]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepo _repo;

    public UserController(IUserRepo repo)
    {
        this._repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _repo.GetAllAsync();
    }

    [HttpGet("{username}", Name = nameof(GetUser))]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetUser(string username)
    {
        User? u = await _repo.GetByUsernameAsync(username);

        return u is not null ? Ok(u) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(User))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateUser([FromBody] User u)
    {
        if (u == null)
        {
            return BadRequest();
        }

        User? newUser = await _repo.CreateAsync(u);

        if (newUser == null)
        {
            return BadRequest();
        } 
        else
        {
            return Ok(u);
        }
    }
}
