using BrainboxApi.Data;
using BrainboxApi.Repository.Implementations;
using BrainboxApi.Repository.IRepository;
using BrainboxApi.Services.Implementation;
using BrainboxApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BrainboxApi.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddAutoMapper(typeof(Program));
            services.AddDbContext<BrainboxDbContext>(options => options.UseSqlServer(config.GetConnectionString("DbConnectionString")));
            return services;
        }
    }
}
