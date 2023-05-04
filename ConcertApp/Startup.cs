using ConcertApp.API.DependencyRegistration;
using ConcertApp.API.Middlewares;
using ConcertApp.API.Requests.Users;
using ConcertApp.API.Utility;
using ConcertApp.API.Utility.CustomModelBinders;
using ConcertApp.Business.Versions.Handlers;
using ConcertApp.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcertApp.API
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
            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));

            services.AddDbContext<ConcertAppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringTrimmer()))
                .AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new CustomModelBinderProvider()));

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>());

            services.AddControllers();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(Startup).Assembly, typeof(GetVersionQueryHandler).Assembly);
            });

            services.AddSwaggerGen();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            services.RegisterServices();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}