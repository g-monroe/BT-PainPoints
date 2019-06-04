using BTSuggestions.Managers;
using BTSuggestions.Core.Interfaces.Managers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddTransient<ICommentManager, CommentManager>();
            services.AddTransient<IPainPointManager, PainPointManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IContentManager, ContentManager>();
            return services;
        }
    }
}
