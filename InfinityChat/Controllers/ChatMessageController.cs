using InfinityChat.Models;
using InfinityChat.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfinityChat.Controllers;

public class ChatMessageController : Controller
{
    public List<ChatMessage> GetAll()
    {
        using (ChatContext db = new ChatContext(ApplicationSettingsService.Configuration))
        {
            var query = from chatMessage in db.ChatMessages orderby chatMessage.Id descending select chatMessage;
            return query.ToList();
        }
    }

    public ChatMessage? GetById(int id)
    {
        using (ChatContext db = new ChatContext(ApplicationSettingsService.Configuration))
        {
            var query = from chatMessage in db.ChatMessages where chatMessage.Id == id select chatMessage;
            return query.FirstOrDefault();
        }
    }

    public void AddChatMessage(ChatMessage chatMessage)
    {
        using (ChatContext db = new ChatContext(ApplicationSettingsService.Configuration))
        {
            db.ChatMessages.Add(chatMessage);
            db.SaveChanges();
        }
    }
    
    public void Create(string Author, string Message)
    {
        AddChatMessage(new ChatMessage()
        {
            Author = Author,
            Message = Message,
            TimeStamp = DateTime.Now
        });
    }
}