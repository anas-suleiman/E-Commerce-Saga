using Identity.SDK.Models;

namespace Identity.Core.Mappers
{
    public class IdentityMapper : IIdentityMapper
    {

        public DataAccess.Identity ToDbModel(IdentitySDKModel sdkModel)
        {
            return new DataAccess.Identity
            {
                Id = sdkModel.Id,
                Email = sdkModel.Email,
                Password = sdkModel.Password
            };
        }

        public IdentitySDKModel ToSDKModel(DataAccess.Identity dbModel)
        {
            return new IdentitySDKModel
            {
                Id = dbModel.Id,
                Email = dbModel.Email,
                Password = dbModel.Password
            };
        }
    }
}
