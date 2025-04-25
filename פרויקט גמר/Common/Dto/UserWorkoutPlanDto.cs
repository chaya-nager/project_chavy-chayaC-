
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class UserWorkoutPlanDto
    {
     
        public int Id { get; set; }

        public int UserId { get; set; }
    
        public int VideoId { get; set; }

    }
}
