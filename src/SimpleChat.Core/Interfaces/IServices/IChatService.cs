using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Core.Interfaces.IServices
{
    public interface IChatService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByChatName(string name);

        Task<bool> AddChat(T book);
        Task<T> DeleteChat(int id, int idd);
    }
}
