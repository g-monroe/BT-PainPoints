using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class PainPointResponse
    {
        public int PainPointId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Annotation { get; set; }
        public string Status { get; set; }
        public int PriorityLevel { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string ComapnyLocation { get; set; }
        public string CreatedOn { get; set; }
        public string IndustryType { get; set; }
    }
}
