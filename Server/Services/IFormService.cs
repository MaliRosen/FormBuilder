using ServerApp.DTOs;
using ServerApp.Entities;

namespace ServerApp.Services
{
    public interface IFormService
    {
        Task<IEnumerable<FormResponseDto>> GetAllAsync();
        Task<FormResponseDto?> GetByIdAsync(int id);
        Task<FormResponseDto> CreateAsync(CreateFormDto dto);
    }
}