﻿using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}
