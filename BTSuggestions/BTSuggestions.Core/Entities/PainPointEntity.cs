using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    public class PainPointEntity : BaseEntity
    {
        [MaxLength(150)]
        [MinLength(2)]
        [Required]
        public string Title { get; set; }
        [MaxLength(1500)]
        [MinLength(2)]
        [Required]
        public string Summary { get; set; }
        [MaxLength(1500)]
        #nullable enable
        public string? Annotation { get; set; }
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Status { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; } //ForiegnKey to UserId
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

        //Strictly for creating the handles for Type to PainPoint
        public IList<PainPointTypeEntity> TypeEntities { get; set; }

        public IEnumerable<string> Types
        {
            get
            {
                return TypeEntities.Select(sa => sa.Type.Name);
            }
        }

        public PainPointEntity()
        {
            Status = "";
            User = new UserEntity();
           TypeEntities= new List<PainPointTypeEntity>();
        }
    }
}
