﻿using BTSuggestions.Core.Entities;
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
        public User User { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContatact { get; set; }
        public string CompanyLocation { get; set; }
        public string IndustryType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}