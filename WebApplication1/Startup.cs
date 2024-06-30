using InvestmentPortfolioManagement.Common.AutoMapper;
using InvestmentPortfolioManagement.Data.Context;
using InvestmentPortfolioManagement.Data.Repository;
using InvestmentPortfolioManagement.Notification;
using InvestmentPortfolioManagement.Services.App;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFundoImobiliarioService, FundoImobiliarioService>();
            services.AddScoped<IInvestimentoService, InvestimentoService>();
            services.AddScoped<IOperacaoService, OperacaoService>();
            
            services.AddScoped<IFundoImobiliarioRepository, FundoImobiliarioRepository>();
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();

            var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            AutoMapper.IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<DataBaseContextApplication>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddSingleton(provider =>
            {
                var scheduler = QuartzConfig.Start().GetAwaiter().GetResult();
                return scheduler;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Investment Portfolio Management API",
                    Description = "API para gerenciar portfólios de investimentos",
                    Contact = new OpenApiContact
                    {
                        Name = "Natan Inacio Chaves",
                        Email = "nataninacio1chaves@gmail.com",
                        Url = new Uri("https://github.com/NatanChaves")
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investment Portfolio Management API V1");
                    c.RoutePrefix = string.Empty; // Define o Swagger UI na raiz do aplicativo
                });
            }

            var scheduler = app.ApplicationServices.GetRequiredService<IScheduler>();
            scheduler.Start().GetAwaiter().GetResult();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
