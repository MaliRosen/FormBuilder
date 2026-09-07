namespace ServerApp.DTOs
{
    public class FormResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<FormFieldResponseDto> Fields { get; set; } = new();
        public List<ApprovalStepResponseDto> ApprovalSteps { get; set; } = new();
    }

    public class FormFieldResponseDto
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string FieldType { get; set; } = string.Empty;
    }

    public class ApprovalStepResponseDto
    {
        public int Id { get; set; }
        public int StepOrder { get; set; }
        public string StepName { get; set; } = string.Empty;
        public string Approver { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
    }
}
