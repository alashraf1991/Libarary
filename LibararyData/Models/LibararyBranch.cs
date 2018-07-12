﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibararyData.Models
{
    public class LibararyBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }


        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibararyAssets> LibararyAssets { get; set; }

        public string ImageUrl { get; set; }
    }
}
