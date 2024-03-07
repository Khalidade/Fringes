using AutoMapper;
using Fringes.Dtos;
using Fringes.Models;
using Microsoft.EntityFrameworkCore;

namespace Fringes.Services
{
    public class MessageService : IMessageService
    {
        private readonly FringeAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MessageService(FringeAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<MessageDto> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            _appDbContext.Messages.Add(message);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<MessageDto>(message);
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _appDbContext.Messages.FindAsync(id);
            if (message == null)
            {
                throw new KeyNotFoundException($"Message with id {id} not found");
            }

            _appDbContext.Messages.Remove(message);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<MessageDto> GetMessageAsync(int id)
        {
            var message = await _appDbContext.Messages.FindAsync(id);
            return _mapper.Map<MessageDto>(message);

        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync()
        {
            var messages = await _appDbContext.Messages.ToListAsync();
            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task UpdateMessageAsync(int id, UpdateMessageDto updateMessageDto)
        {
            var message = await _appDbContext.Messages.FindAsync(id);
            _mapper.Map(updateMessageDto, message);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
