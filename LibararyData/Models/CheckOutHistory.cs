using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibararyData.Models
{
   public class CheckOutHistory
    {
        public int Id { get; set; }

        [Required]
        public LibararyAssets libararyAssets { get; set; }

        [Required]
        public LibararyCard libararyCard { get; set; }

        [Required]
        public DateTime CheckedOut{ get; set; }
        
        public DateTime? CheckedIn { get; set; }
    }
}
