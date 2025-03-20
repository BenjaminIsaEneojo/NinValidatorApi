namespace NINValidatorAPI.ApiModels.Responses
{
    public class NinInfoSummaryResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string NIN { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
