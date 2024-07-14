using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaosYu.Utilities.Configs
{
    public static class Extension
    {
        public static IServiceCollection AddConfig<TConfig>(this IServiceCollection services) where TConfig: class, new()
        {
            return services.AddSingleton(Config.LoadConfig<TConfig>());
        }
    }
}
