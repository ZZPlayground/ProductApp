namespace ProductApp.Utilities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Auto-incremented by database

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Default to current date/time on creation

        public DateTime? UpdatedDate { get; set; } // Nullable, will be set when updated
    }
}