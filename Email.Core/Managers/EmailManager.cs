using Email.Core.Mappers;
using Email.DataAccess;
using Email.SDK.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.Core.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly EmailDbContext _dbContext;
        private readonly IEmailMapper _emailMapper;

        public EmailManager(EmailDbContext dbContext, IEmailMapper emailMapper)
        {
            _dbContext = dbContext;
            _emailMapper = emailMapper;
        }

        public async Task<int> CreateEmail(EmailSDKModel sdkModel)
        {
            var dbModel = _emailMapper.ToDbModel(sdkModel);
            _dbContext.Add(dbModel);
            await _dbContext.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task<List<EmailSDKModel>> GetAllEmails()
        {
            return await _dbContext.Emails.AsNoTracking().Select(s => _emailMapper.ToSDKModel(s)).ToListAsync();
        }
    }
}
