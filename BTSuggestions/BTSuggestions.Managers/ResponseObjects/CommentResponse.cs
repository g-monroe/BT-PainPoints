using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class CommentResponse
    {
        public int CommentId { get; set; }
        public int IssueId { get; set; }
        public User User { get; set; }
        public string CommentText { get; set; }
        public string Status { get; set; }
        public DateTime createdOn { get; set; }
    }
}
