namespace SimpleChat.Api.Interfaces
{
    public interface IChatClient
    {
        Task ReceiveMessage(string userName, string content);
    }
}