using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
namespace BTSuggestions.Core.Entities
{
    public class TypeEntity : BaseEntity
    {
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public IList<PainPointTypeEntity> TypeEntities { get; set; }

        public TypeEntity()
        {
            TypeEntities = new List<PainPointTypeEntity>();
        }
    }
}
