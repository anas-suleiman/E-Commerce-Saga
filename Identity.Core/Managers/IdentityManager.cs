using Identity.Core.Mappers;
using Identity.DataAccess;
using Identity.SDK.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Core.Managers
{
    public class IdentityManager : IIdentityManager
    {
        private readonly IdentityDbContext _context;
        private readonly IIdentityMapper _identityMapper;

        public IdentityManager(IdentityDbContext context, IIdentityMapper identityMapper)
        {
            _context = context;
            _identityMapper = identityMapper;
        }

        public async Task<int> CreateLogin(IdentitySDKModel sdkModel)
        {
            var dbModel = _identityMapper.ToDbModel(sdkModel);
            _context.Add(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task<List<IdentitySDKModel>> GetAllLogins()
        {
            return await _context.Identities.AsNoTracking().Select(s => _identityMapper.ToSDKModel(s)).ToListAsync();
        }

        public async Task<bool> DeleteLogin(int identityId)
        {
            try
            {
                var identity = await _context.Identities.FirstOrDefaultAsync(f => f.Id == identityId);
                _context.Identities.Remove(identity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
