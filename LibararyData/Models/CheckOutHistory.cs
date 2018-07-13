﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
   public class CheckOutHistory
    {
        public int Id { get; set; }

        [Required]
        public LibraryAssets libraryAssets { get; set; }

        [Required]
        public LibraryCard libraryCard { get; set; }

        [Required]
        public DateTime CheckedOut{ get; set; }
        
        public DateTime? CheckedIn { get; set; }
    }
}
