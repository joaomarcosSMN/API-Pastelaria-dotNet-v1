using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PastelariaSMN.Data;
using PastelariaSMN.Infra;
using PastelariaSMN.Middleware;

namespace PastelariaSMN
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();

            // services.AddScoped<IRepository, Repository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // Configuração de variável de ambiente
            // If you want to apply changes without restarting the app, 
            // you need to change the registration code to use AddScoped instead of AddSingleton 

            services.AddScoped<Connection, Connection>();

            services.AddSingleton<EmailSettings>(
                Configuration.GetSection("EmailSettings")
                    .Get<EmailSettings>(options => options.BindNonPublicProperties = true)
            );

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorHandling));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
