using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibararyData.Models
{
   public abstract class LibararyAssets
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }

        public virtual LibararyBranch Location { get; set; }
    }
}
