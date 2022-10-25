using Resty.Core.Interfaces.Enums.User;

namespace Resty.Data.Interfaces.DTO.User
{
    public interface IDataAuthor : IDataBaseModel
    {
        string Username { get; }

        int Rating { get; }

        UserRoles Role { get; }
    }
}
