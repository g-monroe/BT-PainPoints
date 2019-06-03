using BTSuggestions.Engines;
using BTSuggestions.Core.Interfaces.Engines;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddTransient<ICommentEngine, CommentEngine>();
            services.AddTransient<IUserEngine, UserEngine>();
            services.AddTransient<IPainPointEngine, PainPointEngine>();
            services.AddTransient<ITypeEngine, TypeEngine>();
            services.AddTransient<IContentEngine, ContentEngine>();
            return services;
        }
    }
}