using BTSuggestions.Core.Interfaces.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.Infastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddTransient<ICommentManager, CommentManager>();
            services.AddTransient<IPainPointManager, PainPointManager>();
            services.AddTransient<IUserManager, UserManager>();

            return services;
        }
    }
}
