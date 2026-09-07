namespace ServerApp.DTOs
{
    public class CreateFormDto
    {
        public string Name { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public List<FormFieldDto> Fields { get; set; } = new();

        public List<ApprovalStepDto> ApprovalSteps { get; set; } = new();
    }
}