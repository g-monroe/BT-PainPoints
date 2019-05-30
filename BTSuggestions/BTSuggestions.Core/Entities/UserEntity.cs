using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(120)]
        [MinLength(1)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string Username { get; set; }
        [Required]
        [MaxLength(80)]
        [MinLength(1)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(80)]
        [MinLength(1)]
        public string Lastname { get; set; }
        [Required]
        [MinLength(10)]
        public string Password { get; set; }
        [Required]
        public int Privilege { get; set; }
    }
}
