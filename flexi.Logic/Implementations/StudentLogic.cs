using flexi.Entities;
using flexi.Repository;

namespace flexi.Logic;

public class StudentLogic : IStudentLogic
{
  private readonly IStudentRepository _studentRepo;

  public StudentLogic(IStudentRepository studentRepository)
  {
    _studentRepo = studentRepository;
  }

  public Task<IEnumerable<Student>> GetAllStudents(){
    return _studentRepo.GetAllStudents();
  }

  public Task<Student> AddStudent(Student studentInfo)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(studentInfo.StudentFirstName, nameof(studentInfo));
    ArgumentException.ThrowIfNullOrWhiteSpace(studentInfo.StudentLastName, nameof(studentInfo));
    ArgumentException.ThrowIfNullOrWhiteSpace(studentInfo.StudentEmail, nameof(studentInfo));
    ArgumentException.ThrowIfNullOrWhiteSpace(studentInfo.StudentPassword, nameof(studentInfo));

    return _studentRepo.AddStudent(studentInfo);
  }
}
