using System;
using System.Collections.Generic;
using System.Text;

namespace LibararyData.Models
{
   public class Hold
    {
        public int Id { get; set; }
        public virtual LibararyAssets LibararyAssets { get; set; }
        public virtual LibararyCard LibararyCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
