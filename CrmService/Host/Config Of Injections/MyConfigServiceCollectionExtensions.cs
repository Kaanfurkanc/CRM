using Core.GenericRepository;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using DomainServices;
using Repository.GenericRepository;
using Repository.UnitOfWork;
using Repository;
using DomainServices.Mapping;
using Host.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Caching.RedisCachingInterfaces;
using Caching.CachingRedisService;

namespace Host.ConfigOfInjections
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(
                                    this IServiceCollection services)
        {
            services.AddCors();

            //Redis 
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
            });

            //Redis Service 
            services.AddScoped(typeof(IRedisCachingService<>), typeof(RedisCachingService<>));
            //Design patterns Injections
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
 
            // Service Injections 
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<DomainServices.ITeacherService, TeacherService>();

            // Mapping Injection 
            services.AddAutoMapper(typeof(MapProfile));

            return services;
        }
    }
}
