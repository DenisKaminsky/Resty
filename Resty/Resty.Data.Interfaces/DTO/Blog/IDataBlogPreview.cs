namespace Resty.Data.Interfaces.DTO.Blog
{
    public interface IDataBlogPreview : IDataBaseBlogInfo
    {
        string Preview { get; }

        int Rating { get; }

        int NumberOfComments { get; }

        int NumberOfBookmarks { get; }

        int NumberOfViews { get; }
    }
}
