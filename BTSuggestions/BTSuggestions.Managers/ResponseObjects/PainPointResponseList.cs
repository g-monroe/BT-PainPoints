using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class PainPointResponseList
    {
        public int TotalResults { get; set; }
        public List<PainPointResponse> PainPointsList { get; set; }
    }
}
