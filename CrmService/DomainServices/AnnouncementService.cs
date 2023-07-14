using Caching.RedisCachingInterfaces;
using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DomainServices
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AnnouncementService> _logger;
        private readonly IRedisCachingService<Announcement> _redisCachingService;
        private readonly IGenericRepository<Announcement> _repository;
        private const string cacheKey = "announcements";
        public AnnouncementService(IGenericRepository<Announcement> repository, IConfiguration configuration, ILogger<AnnouncementService> logger, IRedisCachingService<Announcement> redisCachingService)
        {
            _repository = repository;
            _configuration = configuration;
            _logger = logger;
            _redisCachingService = redisCachingService;
        }

        public async Task AddAsync(Announcement announcement)
        {
            await _repository.AddAsync(announcement);
            await _redisCachingService.AddToRedisCacheAsync(cacheKey);
        }

        public async Task DeleteAsync(int id)
        {
            var announcement = await _repository.GetByIdAsync(id);
            _repository.Delete(announcement);
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            var cacheStatus = _configuration.GetSection("RedisService:Status").Value;
            if (cacheStatus == "ON" && (await _redisCachingService.GetAllFromRedisAsync(cacheKey) != null))
            {
                _logger.LogInformation($"-------------------------->>>>>>>>>>>>>>>>>Cache İÇİNDE <<<<<<<<<<<<<<<---------------{cacheStatus}--------");
                return await _redisCachingService.GetAllFromRedisAsync(cacheKey);
            }
            else
            {
                var announcements = await _repository.GetAllAsync();
                await _redisCachingService.AddToRedisCacheAsync(cacheKey);
                _logger.LogInformation("-------------------------->>>>>>>>>>>>>>>>>Cache dIŞINDA <<<<<<<<<<<<<<<-----------------------");
                return announcements.ToList();
            }
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            var announcement = await _repository.GetByIdAsync(id);
            return announcement;
        }

        public async Task UpdateAsync(int id, Announcement announcement)
        {
            var announcementDb = await _repository.GetByIdAsync(id);
            if (announcementDb != null)
            {
                announcementDb.Title = announcement.Title;
                announcementDb.Description = announcement.Description;
                announcementDb.SchoolId = announcement.SchoolId;
                _repository.Update(announcementDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Announcement> Where(Expression<Func<Announcement, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
