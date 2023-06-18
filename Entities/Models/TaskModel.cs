namespace Entities.Models
{
    public class TaskModel{
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Owner { get; set; }
        public string? Role { get; set; }
        public string? Mentions { get; set; }
        public string? Status { get; set; }
        public string? Workspace { get; set; }

    }
}