using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Entities
{
    public class KeywordEntity : BaseEntity
    {
        public int PainPointID { get; set; }
        public PainPointEntity PainPoint { get; set; }
        public string TaggedDescription { get; set; }
        public int Score { get; set; }

    }
}
