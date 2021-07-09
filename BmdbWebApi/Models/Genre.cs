﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BmdbWebApi.Models {
    public class Genre {

        public int Id { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }
    }
}
