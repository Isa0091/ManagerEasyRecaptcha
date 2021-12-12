using ManagerEasyRecaptcha.Abstract;
using ManagerEasyRecaptcha.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyRecaptcha.Injection
{
    public static class ManagerEasyRecaptchaExtension
    {
        /// <summary>
        /// Agrega la injeccion de dependencias
        /// </summary>
        /// <param name="services"></param>
        public static void AddManagerEasyRecaptcha(this IServiceCollection services, ManagerEasyRecaptchaConfiguration managerEasyRecaptchaConfiguration)
        {
            services.AddHttpClient();
            services.AddScoped<IManagerEasyRecaptchaProvider>(x => 
                                new ManagerEasyRecaptchaProvider(x.GetService<IHttpClientFactory>().CreateClient(), managerEasyRecaptchaConfiguration));
        }
    }
}
