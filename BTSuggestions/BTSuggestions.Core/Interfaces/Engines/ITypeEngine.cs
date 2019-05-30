using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface ITypeEngine
    {
        Task<IList<TypeEntity>> GetTypesByPainPointId(int id);
    }
}
