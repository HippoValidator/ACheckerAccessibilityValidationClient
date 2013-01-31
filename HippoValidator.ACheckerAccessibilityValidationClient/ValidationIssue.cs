namespace HippoValidator.ACheckerAccessibilityValidationClient
{
    public class ValidationIssue
    {
        public int? Row { get; set; }

        public int? Column { get; set; }

        public string Title { get; set; }

        public string Source { get; set; }
    }
}