using Resty.Core.Interfaces.Enums.User;

namespace Resty.Business.Interfaces.DTO.User
{
    public interface IUser: IBaseUnit
    {
        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string Email { get; }

        int Rating { get; }

        DateTime StartDateUtc { get; }

        DateTime? EndDateUtc { get; }

        UserRoles Role { get; }
    }
}
