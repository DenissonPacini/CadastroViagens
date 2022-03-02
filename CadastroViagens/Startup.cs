using CadastroViagens.Data;
using CadastroViagens.Interfaces;
using CadastroViagens.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;

namespace CadastroViagens
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Essa variável pega minha string de conexão no arquiovo appsetting.json
            string connectionString = Configuration.GetConnectionString("Oracle");

            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AppDbContext>(options => options.UseOracle(connectionString));

            /* //teste de conexão com o Oracle*/
            //using (OracleConnection connection = new OracleConnection(connectionString))
            //{
            //    connection.Open();
            //    string teste = ("ServerVersion: " + connection.ServerVersion
            //        + "\nDataSource: " + connection.DataSource + " Nome do banco" + connection.Database);
            //}
            services.AddDbContext<AppDbContext>();

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IRepositorioMotorista, RepositorioMotorista>();
            services.AddTransient<IRepositorioViagem, RepositorioViagem>();
            services.AddTransient<IRepositorioBuscaMotorista, RepositorioBuscaMotorista>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<IDataService>().InicializaDb();
        }
    }
}
