using Email.SDK.Models;

namespace Email.Core.Managers
{
    public interface IEmailManager
    {
        Task<int> CreateEmail(EmailSDKModel sdkModel);
        Task<List<EmailSDKModel>> GetAllEmails();
    }
}