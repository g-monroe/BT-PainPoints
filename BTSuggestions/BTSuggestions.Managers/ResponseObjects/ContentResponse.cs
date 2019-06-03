using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class ContentResponse
    {
        public int ContentId { get; set; }
        public string Content { get; set; }
        public virtual UserEntity User { get; set; }
        public int UserId { get; set; } //ForiegnKey to UserId
    }
}
