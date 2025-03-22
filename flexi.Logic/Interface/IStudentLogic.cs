using flexi.Entities;

namespace flexi.Logic;

public interface IStudentLogic
{
  public Task<IEnumerable<Student>> GetAllStudents();
  public Task<Student> AddStudent(Student studentInfo); 
}
