using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Certificate;


namespace RAP.Administrator.Infrastructure.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ApplicationDbContext _context;

        public CertificateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<CertificateEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Certificates
                .Include(c => c.Localizations)
                .Include(c => c.CertificateType)
                .Include(c => c.Employee)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<CertificateEntity?> GetByIdAsync(int id)
        {
            return await _context.Certificates
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .Include(c => c.Exports)
                .Include(c => c.CertificateType)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CertificateEntity> CreateAsync(CertificateEntity entity, int userId, string language)
        {
            _context.Certificates.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<CertificateEntity> entities, int userId, string language)
        {
            _context.Certificates.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(CertificateEntity entity, int userId, string language)
        {
            var existing = await _context.Certificates
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            existing.CertificateNumber = entity.CertificateNumber;
            existing.CertificateTypeId = entity.CertificateTypeId;
            existing.EmployeeId = entity.EmployeeId;
            existing.LabManager = entity.LabManager;
            existing.GeneralManager = entity.GeneralManager;
            existing.Description = entity.Description;
            existing.Date = entity.Date;
            existing.ActionTypeName = entity.ActionTypeName;

            if (entity.Localizations != null)
            {
                _context.CertificateLocalizations.RemoveRange(existing.Localizations);
                await _context.CertificateLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
            var entity = await _context.Certificates
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return false;

            _context.Certificates.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<CertificateEntity>> GetTemplateDataAsync()
        {
            return await _context.Certificates
                .AsNoTracking()
                .Where(c => c.CertificateTypeId != 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<CertificateAuditEntity>> GetAllAuditsAsync(int certificateId)
        {
            return await _context.CertificateAudits
                .AsNoTracking()
                .Where(a => a.CertificateId == certificateId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int certificateId, int userId, string actionTypeName)
        {
            var certificate = await _context.Certificates.FindAsync(certificateId);
            if (certificate == null)
                throw new Exception($"Certificate with Id {certificateId} not found.");

            var audit = new CertificateAuditEntity
            {
                CertificateId = certificateId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
               
            };

            _context.CertificateAudits.Add(audit);
            await _context.SaveChangesAsync();
        }
    }
}
