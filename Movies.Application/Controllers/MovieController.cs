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

            var domainObj = this._mapper.Map<MovieModel>(viewModel);

            var response = await this._mediator.Send(new CreateMovieCommand(domainObj));

            if (response.Status == "error")
            {
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieModel viewModel)
        {
            if (viewModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var returnModel = new UpdateMovieViewModel();

            var domainObj = this._mapper.Map<MovieModel>(viewModel);

            if (!await this._mediator.Send(new UpdateMovieCommand(domainObj)))
            {
                returnModel.Status = "doesnt exist";

                return StatusCode(StatusCodes.Status404NotFound, returnModel);
            }

            returnModel.Status = "updated";

            return StatusCode(StatusCodes.Status200OK, returnModel);
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
    }
}
