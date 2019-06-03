using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class TypeEngine : ITypeEngine
    {
        
        private readonly ITypeHandler _typeHandler;
        public TypeEngine(ITypeHandler typeHandler)
        {
            _typeHandler = typeHandler;
        }

    }
}
