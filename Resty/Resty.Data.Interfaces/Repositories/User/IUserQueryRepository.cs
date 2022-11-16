﻿using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.Repositories.User
{
    public interface IUserQueryRepository
    {
        Task<IDataUser[]> GetAllAsync();

        Task<IDataUser[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request);

        Task<IDataUser> GetByIdAsync(int id);

        Task<bool> ValidateUsernameExistsAsync(string username);

        Task<bool> ValidateEmailExistsAsync(string email);
    }
}
