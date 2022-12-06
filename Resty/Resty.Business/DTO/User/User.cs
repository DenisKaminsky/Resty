using Resty.Business.Interfaces.DTO.User;
using Resty.Core.Interfaces.Enums.User;

namespace Resty.Business.DTO.User
{
    public class User : BaseUnit, IUser
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
