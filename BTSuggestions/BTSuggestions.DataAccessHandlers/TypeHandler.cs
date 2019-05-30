using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class TypeHandler : BaseHandler<TypeEntity>, ITypeHandler
    {
        public TypeHandler(BTSuggestionContext context) : base(context)
        {
        }

        public async Task<IList<TypeEntity>> GetTypesByPainPointId(int id)
        {
            //var results = await _context.Types.Where(s => s.PainPointId== id).ToListAsync();
            return null;
        }
    }
}
