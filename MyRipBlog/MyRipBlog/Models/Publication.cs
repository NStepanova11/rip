using System;

namespace MyRipBlog.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
