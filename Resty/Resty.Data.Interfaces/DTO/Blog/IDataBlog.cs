namespace Resty.Data.Interfaces.DTO.Blog
{
    public interface IDataBlog : IDataBaseBlogInfo
    {
        string Content { get; }
        
        int UserGrade { get; }
    }
}
