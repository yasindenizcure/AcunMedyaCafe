namespace AcunMedyaCafe.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
