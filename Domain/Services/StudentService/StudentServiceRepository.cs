using System.Runtime.InteropServices.ComTypes;
using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Helper;

namespace ConsoleAppCleanProject.Services.StudentService;

public static class StudentServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Student> _students = new List<Student>();

    // Admin validation
    public static bool ValidateAdmin(string adminId, string password)
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

    // Create
    public static void AddStudent(string name, string age, string address, Gender gender)
    {
        var student = new Student(name, age, address, gender);
        _students.Add(student);
        
    }

// Read by ID
    public static Student GetStudentById(string studentId)
    {
        return _students.Find(x => x.StudentId == studentId);
        
    }

    // Read all
    public static List<Student> GetAllStudents()
    {
        return _students;
    }

    // Delete
    public static bool DeleteStudent(string studentId)
    {
        var student = _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;
    }
}
