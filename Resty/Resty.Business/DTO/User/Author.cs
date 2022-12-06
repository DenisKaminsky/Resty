using Resty.Business.Interfaces.DTO.User;
using Resty.Core.Interfaces.Enums.User;

namespace Resty.Business.DTO.User
{
    public class Author : BaseUnit, IAuthor
    {
        public string Username { get; set; }

        public int Rating { get; set; }

        public UserRoles Role { get; set; }
    }
}
