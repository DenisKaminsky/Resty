using Resty.Core.Interfaces.Enums.User;

namespace Resty.Business.Interfaces.DTO.User
{
    public interface IAuthor: IBaseUnit
    {
        string Username { get; }

        int Rating { get; }

        UserRoles Role { get; }
    }
}
