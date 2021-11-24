using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;
using Suspense.Dal.Infrastructure;
using Suspense.Dal.Models;
using Microsoft.OData.ModelBuilder;

namespace SuspenseService
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
            // This is needed because we are exposing our DAL model so not really fit for serialisation but hey ho
            services.AddControllers().AddNewtonsoftJson(e => e.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddOData();

            services.AddDbContext<SuspenseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SuspenseDb"));
            });

            services.AddMediatR(typeof(Startup).Assembly);

            // Urgh this is all needed for Swagger UI
            services.AddMvc(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Suspense Service API",
                    Description = "API for suspense submissions."
                });

                if (File.Exists(XmlCommentsFilePath))
                    c.IncludeXmlComments(XmlCommentsFilePath);
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Expand().Filter().OrderBy().Count().MaxTop(100);
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Suspense Service V1");
            });
        }

        /// <summary>
        /// Configure our OData model.
        /// </summary>
        /// <returns><see cref="IEdmModel"/> implementation.</returns>
        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            var submissionSet = odataBuilder.EntitySet<Submission>("Submissions");
            submissionSet.EntityType.HasKey(entity => entity.Id);
            submissionSet.EntityType.Expand(SelectExpandType.Automatic, "SubmissionChanges");
            
            var submissionChangesSet = odataBuilder.EntitySet<SubmissionChange>("SubmissionChanges");
            submissionChangesSet.EntityType.HasKey(entity => entity.Id);
            submissionChangesSet.EntityType.Expand(SelectExpandType.Automatic, "SubmissionProperties");

            odataBuilder.EntitySet<SubmissionProperty>("SubmissionProperties").EntityType.HasKey(entity => entity.Id);
            odataBuilder.EntitySet<SubmissionStatus>("SubmissionStatuses").EntityType.HasKey(entity => entity.Id);

            return odataBuilder.GetEdmModel();
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}