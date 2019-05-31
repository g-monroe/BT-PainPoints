using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.ResponseObjects
{
    public class KeywordResponse
    {
        public int KeywordId { get; set; }
        public int PainPointID { get; set; }
        public PainPointEntity PainPoint { get; set; }
        public string TaggedDescription { get; set; }
        public int Score { get; set; }
    }
}
