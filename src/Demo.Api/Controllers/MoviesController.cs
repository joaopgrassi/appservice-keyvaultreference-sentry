using System;
using System.Threading.Tasks;
using Demo.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _dbContext;

        public MoviesController(MoviesDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IActionResult> Get()
        {
            var movies = await _dbContext.Movies.ToListAsync();

            return Ok(movies);
        }
    }
}