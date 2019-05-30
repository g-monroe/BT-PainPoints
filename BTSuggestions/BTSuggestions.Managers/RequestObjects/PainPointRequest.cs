using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.RequestObjects
{
    public class PainPointRequest
    {
        public int PainPointId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Annotation { get; set; }
        public IList<TypeEntity> Type { get; set; }
        public string Status { get; set; }
        public int PriorityLevel { get; set; }
        public UserEntity User { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyLocation { get; set; }
        public string IndustryType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
