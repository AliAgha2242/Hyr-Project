namespace HYR_Blog.CoreLayer.Dtos.CommentDtos;

public class CreateCommentDto
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Score { get; set; }
    public int UserId { get; set; }
}