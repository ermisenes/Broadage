using AutoMapper;
using BroadageBusiness.AutoMapping;
using BroadageBusiness.Logger;
using BroadageBusiness.Services;
using BroadageData;
using BroadageData.Repositories;
using BroadageEntity;
using BroadageEntity.IRepositories;
using BroadageEntity.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;

namespace BroadageUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BroadageDBContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IScoreRepository, ScoreRepository>();

            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMatchRepository, MatchRepository>();

            services.AddScoped<IHomeTeamService, HomeTeamService>();
            services.AddScoped<IHomeTeamRepository, HomeTeamRepository>();

            services.AddScoped<IAwayTeamService, AwayTeamService>();
            services.AddScoped<IAwayTeamRepository, AwayTeamRepository>();

            services.AddScoped<IRoundService, RoundService>();
            services.AddScoped<IRoundRepository, RoundRepository>();

            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();

            services.AddScoped<IStageService, StageService>();
            services.AddScoped<IStageRepository, StageRepository>();

            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddAutoMapper(typeof(Program).Assembly);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}
