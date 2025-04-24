namespace WebAppInterview.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAllStudent();
        void AddStudent(Student student);

    }
}
