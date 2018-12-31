using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.T5B;
using Interface;
using Interface.FTD;
using Interface.T5B;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Models.T5B;
using Swashbuckle.AspNetCore.Swagger;

namespace Taken5Bart
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
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            services.AddDbContext<GameContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ISpelerService, SpelerService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ISessieService, SessieService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuizScoreService, QuizScoreService>();
            services.AddScoped<IPuzzelService, PuzzelService>();
		    services.AddScoped<ISteenScoreService, SteenScoreService>();
            services.AddScoped<IFindTheDifferenceService, FindTheDifferenceService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddMvc();
            services.Configure<FormOptions>(options =>

            {

                options.ValueLengthLimit = int.MaxValue;

                options.MultipartBodyLengthLimit = int.MaxValue;

                options.MultipartHeadersLengthLimit = int.MaxValue;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GameContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("EnableCORS");
            app.UseStaticFiles();
            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });
            DbInit.Initialize(context);
        }
    }
}
