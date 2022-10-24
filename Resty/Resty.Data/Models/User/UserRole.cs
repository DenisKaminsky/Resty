using Resty.Data.Models.Base;

namespace Resty.Data.Models.User
{
    public class UserRole : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
