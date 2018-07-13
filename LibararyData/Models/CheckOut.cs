using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
  public  class CheckOut
    {

        public int Id { get; set; }

        [Required]
        public LibraryAssets libraryAssets { get; set; }
        public LibraryCard libraryCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

    }
}
