using Email.SDK.Models;

namespace Email.Core.Mappers
{
    public class EmailMapper : IEmailMapper
    {
        public DataAccess.Email ToDbModel(EmailSDKModel sdkModel)
        {
            return new DataAccess.Email
            {
                Id = sdkModel.Id,
                Recipient = sdkModel.Recipient,
                Sent = sdkModel.Sent,
            };

        }

        public EmailSDKModel ToSDKModel(DataAccess.Email dbModel)
        {
            return new EmailSDKModel
            {
                Id = dbModel.Id,
                Recipient = dbModel.Recipient,
                Sent = dbModel.Sent,
            };
        }
    }
}
