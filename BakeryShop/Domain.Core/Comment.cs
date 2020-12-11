namespace Domain.Core
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Pie Pie { get; set; }
        public string CommentMessage { get; set; }
    }
}
