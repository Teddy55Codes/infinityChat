using InfinityChat.Models;
using InfinityChat.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfinityChat.Controllers;

public class ChatMessageController
{
    private static ChatContext db = new ChatContext(ApplicationSettingsService.Configuration);
    
    public List<ChatMessage> GetAll()
    {
        var query = from chatMessage in db.ChatMessages select chatMessage;
        return query.ToList();
    }

    public ChatMessage? GetById(int id)
    {
        var query = from chatMessage in db.ChatMessages where chatMessage.Id == id select chatMessage;
        return query.FirstOrDefault();
    }

    public IActionResult CreateMessage(string Author, string Message)
    {
        AddChatMessage(new ChatMessage()
        {
            Author = Author,
            Message = Message,
            TimeStamp = DateTime.Now
        });

        return null;
    }
    
    public void AddChatMessage(ChatMessage chatMessage)
    {
        db.ChatMessages.Add(chatMessage);
        db.SaveChanges();
    }
}