using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class TypeEntity : BaseEntity
    {
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}
