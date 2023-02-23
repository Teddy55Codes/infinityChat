namespace InfinityChat.Models;

public class ChatMessage
{
    public long Id { get; set; }
    public string Author { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }
}