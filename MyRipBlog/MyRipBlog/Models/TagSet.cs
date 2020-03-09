namespace MyRipBlog.Models
{
    public class TagSet
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
