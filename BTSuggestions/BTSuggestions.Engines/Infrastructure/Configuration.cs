using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddTransient<ICommentEngine, CommentEngine>();
            services.AddTransient<IPainPointEngine, PainPointEngine>();
            services.AddTransient<IUserEngine, UserEngine>();

            return services;
        }
    }
}
