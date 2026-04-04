using System.Runtime.InteropServices.ComTypes;
using ConsoleAppCleanProject.Domain;

namespace ConsoleAppCleanProject.Services.StudentService;

public static class StudentServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Student> _students = new List<Student>();
    
    
    
    public static bool ValidateAdmin(string adminId , string password) 
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }
    public static void AddStudent(string name ,string age , string address, Gender gender)
    {
        
        
        _students.Add(new Student(name, age, address, gender));
        Console.WriteLine("Student added successfully");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("-------------------------------");
    }

    public static void  GetStudentbyId(string studentId)
    {
        var student =  _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            Console.WriteLine($"Student found: {student.Name}");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
        
    }
    public static void DeleteStudent(string studentId)
    {
        var student =  _students.Find(x => x.StudentId == studentId);
        if (student != null)
        {
            _students.Remove(student);
            Console.WriteLine("Student removed successfully");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
    public static void  GetAllStudents()
    {
        foreach (var student in _students )
        {
            Console.WriteLine($"Student found: {student.Name} and StudentID {student.StudentId}");
            
        }
    }
    
}