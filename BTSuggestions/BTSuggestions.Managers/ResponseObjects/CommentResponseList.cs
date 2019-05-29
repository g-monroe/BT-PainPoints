using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class CommentResponseList
    {
        public int TotalResults { get; set; }
        public List<CommentResponse> Comments { get; set; }
    }
}
