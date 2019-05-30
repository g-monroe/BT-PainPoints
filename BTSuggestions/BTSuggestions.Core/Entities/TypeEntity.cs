using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class TypeEntity : BaseEntity
    {
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        [Required]
        public virtual PainPointEntity PainPoint { get; set; }

        [Required]
        [ForeignKey("PainPointId")]
        public int PainPointId { get; set; }
    }
}
