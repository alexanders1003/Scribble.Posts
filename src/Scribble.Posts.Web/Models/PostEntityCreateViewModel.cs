namespace Scribble.Posts.Web.Models;

public class PostEntityCreateViewModel
{
    public Guid AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}