using altr_server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using altr_server.data;

namespace altr_server.Controllers
{
    [Route(Routes.communityBase)]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityRepo _repo;

        public CommunityController(ICommunityRepo repo) { this._repo = repo; }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Community))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCommunity([FromBody] Community c)
        {
            if (c is null) return BadRequest();

            Community? newCommunity = await _repo.CreateAsync(c);

            if (newCommunity is null) return BadRequest(); 

            return Ok(newCommunity);
        }

        [HttpGet("{name}", Name = nameof(GetCommunity))]
        [ProducesResponseType(200, Type = typeof(Community))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommunity(string name)
        {
            Community? c = await _repo.GetCommunityByName(name);
        
            if (c is null) return BadRequest();

            return Ok(c);
        }
    }
}
