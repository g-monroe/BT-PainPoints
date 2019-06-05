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
    }
}
