using flexi.Entities;

namespace flexi.Repository;

public interface IStudentRepository
{
  public Task<IEnumerable<Student>> GetAllStudents();
  public Task<Student> AddStudent(Student studentInfo); 
}
