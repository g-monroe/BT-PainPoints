using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class KeywordHandler : BaseHandler<KeywordEntity>, IKeywordHandler
    {

        public KeywordHandler(BTSuggestionContext context) : base(context)
        {
        }
    }
}
