using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.RequestObjects
{
    public class CommentRequest
    {
        public int CommentId { get; set; }
        public int PainPointId { get; set; }
        public PainPointEntity PainPoint { get; set; }
        public UserEntity User { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
