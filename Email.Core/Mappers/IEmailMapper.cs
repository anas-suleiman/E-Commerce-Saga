using Email.SDK.Models;

namespace Email.Core.Mappers
{
    public interface IEmailMapper
    {
        DataAccess.Email ToDbModel(EmailSDKModel sdkModel);
        EmailSDKModel ToSDKModel(DataAccess.Email dbModel);
    }
}