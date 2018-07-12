using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibararyData.Models
{
   public class BranchHours
    {        
        public int Id { get; set; }
        public LibararyBranch Branch { get; set; }

        [Range(0,6)]
        public string DayOfWeek { get; set; }

        [Range(0, 23)]
        public string OpenTime { get; set; }

        [Range(0, 6)]
        public string CloseTime { get; set; }
    }
}
