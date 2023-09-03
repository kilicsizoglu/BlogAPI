namespace BlogAPI;

public class BlogResponse
{
    public Guid key { get; set; }
    public BlogMessage Message { get; set; }
}