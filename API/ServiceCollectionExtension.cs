using Fort.Data.Abstract;
using Fort.Data.Concrete;
using Fort.Services.Abstract;
using Fort.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Fort.Api
{
    public static class ServiceCollectionExtension
    {
        public static void ResolveDependency(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IUserServices), typeof(UserServices));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ICountryServices), typeof(CountryServices));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
        }
    }
}
