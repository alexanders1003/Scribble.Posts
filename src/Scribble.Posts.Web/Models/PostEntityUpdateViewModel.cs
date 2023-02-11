namespace Scribble.Posts.Web.Models;

public class PostEntityUpdateViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}