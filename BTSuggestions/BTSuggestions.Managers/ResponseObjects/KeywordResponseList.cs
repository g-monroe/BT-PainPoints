using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class KeywordResponseList
    {
        public int TotalResults { get; set; }
        public List<KeywordResponse> KeywordsList { get; set; }
    }
}
