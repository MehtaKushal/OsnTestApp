namespace OsnTestApp.Data
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Student> Students { get; set; }
    }
}
