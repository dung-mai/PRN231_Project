namespace BusinessObject.Models
{
    public class Major
    {
        public Major()
        {
            Curricolums = new HashSet<Curricolum>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? MajorName { get; set; }
        public string? MajorCode { get; set; }

        public virtual ICollection<Curricolum> Curricolums { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
