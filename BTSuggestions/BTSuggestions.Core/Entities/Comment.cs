using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        [Required]
        public virtual PainPoint PainPoint { get; set; }
        [Required]
        public int PainPointId { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(1500)]
        public string CommentText { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        public string Status { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
    }
}
