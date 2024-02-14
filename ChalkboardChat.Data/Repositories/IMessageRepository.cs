using ChalkboardChat.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkboardChat.Data.Repositories
{
    public interface IMessageRepository
    {
        public Task<MessageModel?> GetById(int id);
        public Task<MessageModel?> GetByMessage(string message);
        public Task<List<MessageModel>> GetAllMessages();
        public Task<List<MessageModel>> GetAllUserMessages(IdentityUser user);
        public Task AddMessage(MessageModel message);
        public Task DeleteById(int id);
        public Task DeleteByMessage(string message);
        public Task Update(MessageModel message);
        public Task SaveChange();
    }
}
