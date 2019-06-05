using BTSuggestions.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommentHandler, CommentHandler>();
            services.AddTransient<IUserHandler, UserHandler>();
            services.AddTransient<IPainPointHandler, PainPointHandler>();
            services.AddTransient<ITypeHandler, TypeHandler>();
            services.AddTransient<IContentHandler, ContentHandler>();
            return services;
        }
    }
}