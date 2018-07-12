using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibararyData.Models
{
  public  class CheckOut
    {

        public int Id { get; set; }

        [Required]
        public LibararyAssets libararyAssets { get; set; }
        public LibararyCard libararyCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

    }
}
