using ApiChallenger.Enum;

namespace ApiChallenger.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EnumTaskStatus Status { get; set; }
    }
}