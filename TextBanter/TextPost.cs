namespace TextBanter
{
    public class TextPost
    {
        public required string Username { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
    }
}