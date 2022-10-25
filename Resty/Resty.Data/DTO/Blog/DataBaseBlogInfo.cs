﻿using Resty.Core.Interfaces.Enums.Blog;
using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.DTO.Blog
{
    public class DataBaseBlogInfo : DataBaseModel, IDataBaseBlogInfo
    {
        public string Title { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public IDataAuthor Author { get; set; }

        public BlogTypes Type { get; set; }
    }
}
