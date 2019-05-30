using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class TypeResponseList
    {
        public int TotalResults { get; set; }
        public List<TypeResponse> TypesList { get; set; }
    }
}
