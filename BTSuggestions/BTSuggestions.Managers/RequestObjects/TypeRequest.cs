﻿using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.RequestObjects
{
    public class TypeRequest
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public PainPointEntity PainPoint { get; set; }
        public int PainPointId { get; set; }
    }
}
