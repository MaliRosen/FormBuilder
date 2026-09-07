using System.Text.Json.Serialization;

namespace ServerApp.Entities
{
    public class ApprovalStep
    {
        public int Id { get; set; }

        public int FormTemplateId { get; set; }

        public int StepOrder { get; set; }

        public string StepName { get; set; } = string.Empty;

        public string Approver { get; set; } = string.Empty;

        public string ActionType { get; set; } = string.Empty;

        [JsonIgnore]
        public FormTemplate FormTemplate { get; set; } = null!;
    }
}
