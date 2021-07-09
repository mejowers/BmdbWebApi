﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmdbWebApi.Models {
    public class MovieGenre {

        public int Id { get; set; }

        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }

        public virtual Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
