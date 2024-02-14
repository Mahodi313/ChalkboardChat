using ChalkboardChat.Data.Database;
using ChalkboardChat.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkboardChat.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _dbContext;

        public MessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*
         * TODO: Remove methods that is not in use!
         */

        public async Task<List<MessageModel>> GetAllMessages()
        {
            List<MessageModel> messages = await _dbContext.Messages.ToListAsync();

            return messages;
        }

        public async Task<List<MessageModel>> GetAllUserMessages(IdentityUser user)
        {
            List<MessageModel> userMessages = await _dbContext.Messages.Where(m => m.Username == user.UserName).ToListAsync();

            return userMessages;
        }
        public async Task<MessageModel?> GetById(int id)
        {
            MessageModel? message = await FindMessageById(id);

            return message;
        }

        public async Task<MessageModel?> GetByMessage(string message)
        {
            MessageModel? messageToSend = await FindMessageByName(message);

            return messageToSend;
        }
        public async Task Update(MessageModel message)
        {
            MessageModel? messageToUpdate = await _dbContext.Messages.FirstOrDefaultAsync(m => m.Id == message.Id);

            if (messageToUpdate != null)
            {
                messageToUpdate.Message = message.Message;
                messageToUpdate.Date = DateTime.Now;
            }
        }

        public async Task AddMessage(MessageModel message)
        {
            await _dbContext.Messages.AddAsync(message);
        }

        public async Task DeleteById(int id)
        {
            MessageModel? messageToDelete = await FindMessageById(id);

            if (messageToDelete != null)
            {
                _dbContext.Messages.Remove(messageToDelete);
            }
        }

        public async Task DeleteByMessage(string message)
        {
            MessageModel? messageToDelete = await FindMessageByName(message);

            if (messageToDelete != null)
            {
                _dbContext.Messages.Remove(messageToDelete);
            }
        }
        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
        }

        /*
         * Methods for preventing DRY
         */

        private async Task <MessageModel?> FindMessageById(int id)
        {
            MessageModel? message = await _dbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);

            return message;
        }

        private async Task<MessageModel?> FindMessageByName(string message)
        {
            MessageModel? messageToGet = await _dbContext.Messages.FirstOrDefaultAsync(m => m.Message == message);

            return messageToGet;
        }
    }
}
