using Resty.Core.Interfaces.Enums.User;

namespace Resty.Data.Interfaces.DTO.User
{
    public interface IDataUser : IDataBaseModel
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
