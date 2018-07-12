﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibararyData.Models
{
   public class LibararyCard
    {
        public int Id { get; set; }

        public decimal Fees { get; set; }

        public DateTime Created { get; set; }

        public virtual IEnumerable<CheckOut> CheckOuts { get; set; }
    }
}
