﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class WorkoutVideoDto
    {
     
        public int VideoId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Duration { get; set; } // משך הסרטון בדקות

    
        public string DifficultyLevel { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced

        public string WorkoutType { get; set; } = string.Empty; // Cardio, Strength, Yoga...

        public string TargetAudience { get; set; } = string.Empty; // למשל: חולי לב 

        public byte[] VideoUrl { get; set; } 

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    
        public int TrainerId { get; set; }
    }
}
