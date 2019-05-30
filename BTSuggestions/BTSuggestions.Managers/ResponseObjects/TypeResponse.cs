using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class TypeResponse
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public PainPoint PainPoint { get; set; }
        public int PainPointId { get; set; }
    }
}
