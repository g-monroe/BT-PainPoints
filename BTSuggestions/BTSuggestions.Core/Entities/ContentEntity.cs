using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class ContentEntity : BaseEntity
    {
        [Required]
        public string Content { get; set; } 
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; } //ForiegnKey to UserId
    }
}
