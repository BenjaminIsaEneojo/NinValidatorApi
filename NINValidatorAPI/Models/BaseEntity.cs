namespace NINValidatorAPI.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } = "System";
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

