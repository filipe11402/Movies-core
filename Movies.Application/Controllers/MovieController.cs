using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieModel viewModel) 
        {
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
