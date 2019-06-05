using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class ContentResponseList
    {
        public int TotalResults { get; set; }
        public List<ContentResponse> ContentsList { get; set; }
    }
}
