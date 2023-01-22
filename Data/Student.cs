using System.ComponentModel.DataAnnotations.Schema;

namespace OsnTestApp.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<StudentMark> Marks { get; set; }
        public Parent Parent { get; set; }
        public int ParentId { get; set; }
    }
}
