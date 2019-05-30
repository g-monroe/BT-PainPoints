using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Entities
{
   public class PainPointTypeEntity : BaseEntity
    {
        //<<summary>
        //This is overall to link the two together looking at the Example.
        //From the dotnet-testing solution. Trying to apply there example to this.
        //
        //</summary>
        public int PainPointId { get; set; }
        [JsonIgnore]
        public PainPointEntity PainPoint { get; set; }
        public int TypeId { get; set; }
        public TypeEntity Type { get; set; }
    }
}
