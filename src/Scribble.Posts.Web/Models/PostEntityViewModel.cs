using Scribble.Posts.Models;

namespace Scribble.Posts.Web.Models;

public class PostEntityViewModel
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime PostedAt { get; set; }
    public bool IsPosted { get; set; }
    public IEnumerable<Guid> TagIds { get; set; } = null!;
    public IEnumerable<Guid> CommentIds { get; set; } = null!;
}