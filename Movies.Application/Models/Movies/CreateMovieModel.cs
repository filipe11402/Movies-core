using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Models.Movies
{
    public class CreateMovieModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
    }
}
