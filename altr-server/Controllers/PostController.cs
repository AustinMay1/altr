using altr_server.data;
using Microsoft.AspNetCore.Mvc;
using altr_server.Repositories;

namespace altr_server.Controllers;

[Route(Routes.postBase)]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepo _repo;

    public PostController(IPostRepo repo) { this._repo = repo; }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Post))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreatePost([FromBody] Post p)
    {
        if (p is null) return BadRequest();

        Post? newPost = await _repo.CreateAsync(p);

        if (newPost is null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(p);
        }
    }

    [HttpGet("{id}", Name = nameof(GetPostById))]
    [ProducesResponseType(200, Type = typeof(Post))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        Post? p = await _repo.GetPostsById(id);

        if (p is null) return BadRequest();

        return Ok(p);
    }
}