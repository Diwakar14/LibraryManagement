namespace LibraryManagement.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public Entity()
        {
            Guid = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            CreatedBy = "System";
        }
    }
}
