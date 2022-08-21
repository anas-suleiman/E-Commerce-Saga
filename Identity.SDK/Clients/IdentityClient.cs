using Common.Base;
using Identity.SDK.Clients;
using Identity.SDK.Models;

namespace Identity.SDK
{
    public class IdentityClient : BaseSdkClient, IIdentityClient
    {
        public IdentityClient(HttpClient httpClient) : base(httpClient)
        {
            BaseUrl = ServiceUrl.IdentityServiceUrl;
        }

        public async Task<List<IdentitySDKModel>> GetAllEmails()
        {
            return await SendPlainRequest<List<IdentitySDKModel>>(HttpMethod.Get, $"Identity/GetAllLogins");
        }

        public async Task<int> CreateLogin(IdentitySDKModel sdkModel)
        {
            return await SendJsonRequest<int>(HttpMethod.Post, $"Identity/CreateLogin", sdkModel);
        }

        public async Task<bool> DeleteLogin(int identityId)
        {
            return await SendJsonRequest<bool>(HttpMethod.Post, $"Identity/DeleteLogin", identityId);
        }
    }
}