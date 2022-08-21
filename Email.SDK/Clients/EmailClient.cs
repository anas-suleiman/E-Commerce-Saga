using Common.Base;
using Email.SDK.Models;

namespace Email.SDK.Clients
{
    public class EmailClient : BaseSdkClient, IEmailClient
    {
        public EmailClient(HttpClient httpClient) : base(httpClient)
        {
            BaseUrl = ServiceUrl.EmailServiceUrl;
        }

        public async Task<List<EmailSDKModel>> GetAllEmails()
        {
            return await SendPlainRequest<List<EmailSDKModel>>(HttpMethod.Get, $"Email/GetAllEmails");
        }

        public async Task<int> CreateEmail(EmailSDKModel sdkModel)
        {
            return await SendJsonRequest<int>(HttpMethod.Post, $"Email/CreateEmail", sdkModel);
        }
    }
}