using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Interfaces.IServices
{
    public interface IChatService<T> where T : class
    {
        Task<T> GetChatById(int id);
        Task<T> GetChatByChatName(string name);
        Task<T> GetChatByUserCreatorId(int userCreatorId);

        Task<bool> AddChat(T book);
        Task<T> DeleteBook(int id);
    }
}
