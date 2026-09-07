using System.Text.Json.Serialization;

namespace ServerApp.Entities
{
    public class FormField
    {
        internal int Order;

        public int Id { get; set; }

        public int FormTemplateId { get; set; }

        public string Label { get; set; } = string.Empty;

        public string FieldType { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public bool IsRequired { get; set; }
        [JsonIgnore]
        public FormTemplate FormTemplate { get; set; } = null!;
    }
}
