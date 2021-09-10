using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Entities
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
