using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.RequestObjects
{
    public class KeywordRequest
    {
        public int KeywordId { get; set; }
        public int PainPointID { get; set; }
        public PainPointEntity PainPoint { get; set; }
        public string TaggedDescription { get; set; }
        public int Score { get; set; }
    }
}
