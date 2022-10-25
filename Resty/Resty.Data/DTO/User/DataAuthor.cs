using Resty.Core.Interfaces.Enums.User;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.DTO.User
{
    public class DataAuthor : DataBaseModel, IDataAuthor
    {
        public string Username { get; set; }

        public int Rating { get; set; }

        public UserRoles Role { get; set; }
    }
}
