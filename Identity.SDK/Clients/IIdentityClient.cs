using Identity.SDK.Models;

namespace Identity.SDK.Clients
{
    public interface IIdentityClient
    {
        Task<List<IdentitySDKModel>> GetAllEmails();
        Task<int> CreateLogin(IdentitySDKModel sdkModel);
        Task<bool> DeleteLogin(int identityId);
    }
}