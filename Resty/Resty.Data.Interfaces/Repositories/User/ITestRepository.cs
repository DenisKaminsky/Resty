using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.Repositories.User
{
    public interface ITestRepository
    {
        Task<IDataUser[]> Test1();

        Task<IDataUser> GetByIdAsync(int id);

        Task<bool> ValidateUsernameExistsAsync(string username);

        Task<bool> ValidateEmailExistsAsync(string email);
    }
}
