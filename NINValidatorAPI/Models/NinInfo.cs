using NINValidatorAPI.Models;
using NINValidatorAPI.Models.Enums;

namespace NINValidatorAPI.Models
{
    public class NinInfo : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string NIN { get; set; } = string.Empty;
        public DateTime? VerificationDate { get; set; }
        public NinInfoStatus VerificationStatus { get; set; }
        public string CommonReference { get; set; } = string.Empty;
    }
}