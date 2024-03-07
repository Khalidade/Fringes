using Fringes.Dtos;

namespace Fringes.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetMessagesAsync();
        Task<MessageDto> GetMessageAsync(int id);
        Task<MessageDto> CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(int id, UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);

    }
}
