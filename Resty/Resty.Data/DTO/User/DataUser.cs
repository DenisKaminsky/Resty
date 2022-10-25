using Resty.Core.Interfaces.Enums.User;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.DTO.User
{
    public class DataUser : DataBaseModel, IDataUser
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public UserRoles Role { get; set; }
    }
}
