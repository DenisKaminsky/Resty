﻿using Resty.Core.Interfaces.Enums.Blog;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.DTO.Blog
{
    public interface IDataBaseBlogInfo : IDataBaseModel
    {
        string Title { get; }

        DateTime CreatedDateUtc { get; }

        IDataAuthor Author { get; }

        BlogTypes Type { get; }
    }
}
