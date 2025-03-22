using TechTalk.DatabaseAccessor.Services;
using flexi.Entities;

namespace flexi.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly MySqlDatabaseAccessor _databaseAccessor;

    public StudentRepository(MySqlDatabaseAccessor databaseAccessor)
    {
        _databaseAccessor = databaseAccessor;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        string sql = "SELECT * FROM student";
        return await _databaseAccessor.QueryAsync<Student>(sql); 
    }

    public async Task<Student> AddStudent(Student studentInfo)
    {
        string sql = @"
        INSERT INTO student (studentFirstName, studentLastName, studentEmail, studentPassword) VALUES (@studentFirstName, @studentLastName, @studentEmail, @studentPassword);
        SELECT LAST_INSERT_ID();";

        int newId = await _databaseAccessor.ExecuteScalarAsync<int>(sql, studentInfo); 
        studentInfo.StudentId = newId;
        return studentInfo;
    }
}
