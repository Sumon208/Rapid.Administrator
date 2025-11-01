using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.SampleReceiving;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace RAP.Administrator.Infrastructure.Repositories
{
    public class SampleReceivingRepository : ISampleReceivingRepository
    {
        private readonly ApplicationDbContext _context;

        public SampleReceivingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public async Task<(IEnumerable<SampleReceivingEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.SampleReceivings
                .Include(r => r.Localizations)
                .AsNoTracking()
                .OrderByDescending(r => r.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

     
        public async Task<SampleReceivingEntity?> GetByIdAsync(long id)
        {
            return await _context.SampleReceivings
                .Include(r => r.Localizations)
                .Include(r => r.Audits)
                .Include(r => r.Exports)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

      
        public async Task<SampleReceivingEntity> CreateAsync(SampleReceivingEntity entity, int userId, string language)
        {
            _context.SampleReceivings.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

     
        public async Task<int> CreateBulkAsync(IEnumerable<SampleReceivingEntity> entities, int userId, string language)
        {
            _context.SampleReceivings.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

      
        public async Task<bool> UpdateAsync(SampleReceivingEntity d, int userId, string language)
        {
            var existing = await _context.SampleReceivings
                .Include(r => r.Localizations)
                .FirstOrDefaultAsync(r => r.Id == d.Id);

            if (existing == null)
                return false;

            existing.ReceivingNo = d.ReceivingNo;
            existing.CustomerName = d.CustomerName;
            existing.CustomerReference = d.CustomerReference;
            existing.TypeOfSample = d.TypeOfSample;
            existing.RequiredTests = d.RequiredTests;
            existing.NumberOfSample = d.NumberOfSample;
            existing.Date = d.Date;
            existing.Time = d.Time;

            existing.SectionId= d.SectionId;
            existing.SectionId = d.SectionId;
            existing.ReceivedById = d.ReceivedById;

            

            if (d.Localizations != null)
            {
                _context.SampleReceivedLocalizations.RemoveRange(existing.Localizations);
                await _context.SampleReceivedLocalizations.AddRangeAsync(d.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        // 🟢 Delete
        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.SampleReceivings
                .Include(r => r.Localizations)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (entity == null)
                return false;

            _context.SampleReceivings.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<SampleReceivingEntity>> GetTemplateDataAsync()
        {
            return await _context.SampleReceivings
               
                .ToListAsync();
        }

        
        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>(); 
        }

       
        public async Task<IEnumerable<SampleReceivedAuditEntity>> GetAllAuditsAsync(long receivedId)
        {
            return await _context.SampleReceivedAudits
                .AsNoTracking()
                .Where(a => a.ReceivedId == receivedId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

      
        private async Task AddAuditAsync(int receivedId, int userId, string actionTypeName)
        {
            var entity = await _context.SampleReceivings.FindAsync(receivedId);
            if (entity == null)
                throw new Exception($"SampleReceiving with Id {receivedId} not found.");

            var audit = new SampleReceivedAuditEntity
            {
                ReceivedId = receivedId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                
                Code = "SR", 
                Dail = "001",
                Browser = "N/A",
                Location = "BD",
                IP = "0.0.0.0",
                OS = "N/A",
                MapURL = "",
                Latitude = 0,
                Longitude = 0
            };

            _context.SampleReceivedAudits.Add(audit);
            await _context.SaveChangesAsync();
        }

       
        private short MapActionType(string action) => action switch
        {
            "Create" => 1,
            "CreateBulk" => 2,
            "Update" => 3,
            "Delete" => 4,
            _ => 0
        };
    }
}
