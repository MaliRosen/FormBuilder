using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.DTOs;
using ServerApp.Entities;

namespace ServerApp.Services
{
    public class FormService : IFormService
    {
        private readonly AppDbContext _context;

        public FormService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FormResponseDto>> GetAllAsync()
        {
            var forms = await _context.FormTemplates
                .Include(f => f.Fields)
                .Include(f => f.ApprovalSteps)
                .ToListAsync();

            return forms.Select(MapToDto);
        }

        public async Task<FormResponseDto?> GetByIdAsync(int id)
        {
            var form = await _context.FormTemplates
                .Include(f => f.Fields)
                .Include(f => f.ApprovalSteps)
                .FirstOrDefaultAsync(f => f.Id == id);

            return form == null ? null : MapToDto(form);
        }

        public async Task<FormResponseDto> CreateAsync(CreateFormDto dto)
        {
            var form = new FormTemplate
            {
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.UtcNow
            };

            foreach (var field in dto.Fields)
            {
                form.Fields.Add(new FormField
                {
                    Label = field.Label,
                    FieldType = field.FieldType
                });
            }

            foreach (var step in dto.ApprovalSteps)
            {
                form.ApprovalSteps.Add(new ApprovalStep
                {
                    StepOrder = step.StepOrder,
                    StepName = step.StepName,
                    Approver = step.Approver,
                    ActionType = step.ActionType
                });
            }

            _context.FormTemplates.Add(form);

            await _context.SaveChangesAsync();

            return MapToDto(form);
        }

        private static FormResponseDto MapToDto(FormTemplate form)
        {
            return new FormResponseDto
            {
                Id = form.Id,
                Name = form.Name,
                CreatedBy = form.CreatedBy,
                CreatedAt = form.CreatedAt,

                Fields = form.Fields.Select(field => new FormFieldResponseDto
                {
                    Id = field.Id,
                    Label = field.Label,
                    FieldType = field.FieldType
                }).ToList(),

                ApprovalSteps = form.ApprovalSteps.Select(step => new ApprovalStepResponseDto
                {
                    Id = step.Id,
                    StepOrder = step.StepOrder,
                    StepName = step.StepName,
                    Approver = step.Approver,
                    ActionType = step.ActionType
                }).ToList()
            };
        }
    }
}