
namespace WebAppInterview.Models
{
    public class StudentRepository : IStudentRepository
    {
        //When a new instance of StudentRepository is created,
        //we need to log the Date and time into a text file
        //using the constructor
        public StudentRepository()
        {
            //Please Change the Path to your file path
            string filePath = @"D:\HA\Fs\Project\WebAppInterview\WebAppInterview\Log\Log.txt";
            string contentToWrite = $"StudentRepository Object Created: @{DateTime.Now.ToString()}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(contentToWrite);
            }
        }
        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }

        // Thêm sinh viên mới
        public void AddStudent(Student student)
        {
            DataSource().Add(student);
        }

        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(e => e.StudentId == StudentId) ?? new Student();
        }
        public List<Student> GetAllStudent()
        {
            return DataSource();
        }
    }
}
