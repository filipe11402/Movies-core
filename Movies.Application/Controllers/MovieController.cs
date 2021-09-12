using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Mediator.Commands;
using Movies.Application.Mediator.Queries;
using Movies.Application.Models.Movies;
using Movies.Domain.Models;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MovieController(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieModel viewModel) 
        {
            if (viewModel == null) 
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var domainMovie = this._mapper.Map<MovieModel>(viewModel);

            var movieDto = await this._mediator.Send(new CreateMovieCommand(domainMovie));

            if (movieDto.Status == "error")
            {
                return StatusCode(StatusCodes.Status400BadRequest, movieDto);
            }

            return StatusCode(StatusCodes.Status201Created, movieDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieModel viewModel)
        {
            if (viewModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var movieDto = new UpdateMovieViewModel();

            var domainMovie = this._mapper.Map<MovieModel>(viewModel);

            if (!await this._mediator.Send(new UpdateMovieCommand(domainMovie)))
            {
                movieDto.Status = "doesnt exist";

                return StatusCode(StatusCodes.Status404NotFound, movieDto);
            }

            movieDto.Status = "updated";

            return StatusCode(StatusCodes.Status200OK, movieDto);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteMovie([FromBody] DeleteMovieModel viewModel) 
        {
            if(viewModel == null) 
            
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (!await this._mediator.Send(new DeleteMovieCommand(viewModel.Id))) 
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> FetchMovies()
        {
            return StatusCode(StatusCodes.Status200OK,
                await this._mediator.Send(new GetMoviesQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> FetchMovie([FromQuery] string id) 
        {
            if (id == null) 
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var movieDto = await this._mediator.Send(new GetMovieQuery(id));

            if (movieDto == null) 
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status302Found, movieDto);
        }
    }
}
