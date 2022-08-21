using Identity.SDK.Models;

namespace Identity.Core.Managers
{
    public interface IIdentityManager
    {
        Task<int> CreateLogin(IdentitySDKModel sdkModel);
        Task<List<IdentitySDKModel>> GetAllLogins();
        Task<bool> DeleteLogin(int identityId);
    }
}