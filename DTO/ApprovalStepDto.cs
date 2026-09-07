namespace ServerApp.DTOs
{
    public class ApprovalStepDto
    {
        public int StepOrder { get; set; }

        public string StepName { get; set; } = string.Empty;

        public string Approver { get; set; } = string.Empty;

        public string ActionType { get; set; } = string.Empty;
    }
}