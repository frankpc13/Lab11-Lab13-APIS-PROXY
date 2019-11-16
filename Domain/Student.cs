using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentId { get; set; }
        
        [Required]
        public string StudentName { get; set; }
        
        [Required]
        public string StudentLastname { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public string StudentAddress { get; set; }
        
        [Required]
        public int StudentCode { get; set; }

        public bool isActive { get; set; } = true;
    }
}