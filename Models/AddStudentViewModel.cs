using OsnTestApp.Data;

namespace OsnTestApp.Models
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<StudentMark> Marks { get; set; }
        public string PName { get; set; }
        public string PAddress { get; set; }
        public string PPhone { get; set; }
        public string PEmail { get; set; }
    }
}
