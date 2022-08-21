using Email.SDK.Models;

namespace Email.SDK.Clients
{
    public interface IEmailClient
    {
        Task<List<EmailSDKModel>> GetAllEmails();
        Task<int> CreateEmail(EmailSDKModel sdkModel);
    }
}