namespace ServerApp.DTOs
{
    public class FormFieldDto
    {
        public string Label { get; set; } = string.Empty;

        public string FieldType { get; set; } = string.Empty;

        public int Order { get; set; }

        public bool Required { get; set; }
    }
}