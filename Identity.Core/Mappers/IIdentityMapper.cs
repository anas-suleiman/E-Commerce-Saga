using Identity.SDK.Models;

namespace Identity.Core.Mappers
{
    public interface IIdentityMapper
    {
        DataAccess.Identity ToDbModel(IdentitySDKModel sdkModel);
        IdentitySDKModel ToSDKModel(DataAccess.Identity dbModel);
    }
}