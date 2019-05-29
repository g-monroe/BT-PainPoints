using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class PainPoint : BaseEntity
    {
        [Key]
        [Required]
        public int PainPointId { get; set; }
        [MaxLength(150)]
        [MinLength(2)]
        [Required]
        public string Title { get; set; }
        [Required]
        public int Type { get; set; }
        [MaxLength(1500)]
        [MinLength(2)]
        [Required]
        public string Summary { get; set; }
        [MaxLength(1500)]
        #nullable enable
        public string? Annontation { get; set; }
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Status { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public int PriorityLevel { get; set; }
        #nullable enable
        public string? CompanyName { get; set; }
        #nullable enable
        public string? CompanyContact { get; set; }
        #nullable enable
        public string? CompanyLocation { get; set; }
        #nullable enable
        public string? IndustryType { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
    }
}
