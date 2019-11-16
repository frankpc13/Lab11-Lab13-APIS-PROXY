using System;
using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentLastname { get; set; }

        [Required]
        public int StudentCode { get; set; }
      
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [Required]
        public string StudentAddress { get; set; }

        public bool IsActive { get; set; }
    }
}