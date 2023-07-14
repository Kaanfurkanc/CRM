using AdminPortalApi.ClientServices;
using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.Controllers.v1.ManagementControllers;
using AdminPortalApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortalApi.Extensions
{
    public static class MyConfigServiceCollectionExtensions 
    {
        public static IServiceCollection AddMyDependencyGroup(
                                    this IServiceCollection services) 
        {
            services.AddCors();

            //Client Services Dependencies
            services.AddScoped(typeof(IClientService<>), typeof(SchoolManagementClientService<>));

            services.AddHttpClient<AnnouncementsController>();
            services.AddHttpClient<ClassesController>();
            services.AddHttpClient<CoursesController>();
            services.AddHttpClient<ExamsController>();
            services.AddHttpClient<GradesController>();
            services.AddHttpClient<SchoolsController>();
            services.AddHttpClient<StudentsController>();
            services.AddHttpClient<TeachersController>();



            // Api versioning 
            services.AddApiVersioning(_ =>
            {
                // Default Version 
                _.DefaultApiVersion = new ApiVersion(1, 0);
                _.AssumeDefaultVersionWhenUnspecified = true;
                _.ReportApiVersions = true;
            });

            return services;
        }
    }
}
