using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Helper;

namespace ConsoleAppCleanProject.Services.StudentService;

public static class LecturerServiceRepository
{
    private static Admin _admin = new Admin();
    private static List<Lecturer> _lecturers = new List<Lecturer>();

// Admin validation
    public static bool ValidateAdmin(string adminId, string password)
    {
        return _admin.AdminId == adminId && _admin.Password == password;
    }

// Create
    public static void AddLecturer(string name, string age, string address, Gender gender)
    {
        var lecturer = new Lecturer(name, age, address, gender);
        _lecturers.Add(lecturer);
        
    }

// Read by ID
    public static Lecturer GetLecturerById(string staffId)
    {
        return _lecturers.Find(x => x.StaffId == staffId);
    }

// Read all
    public static List<Lecturer> GetAllLecturers()
    {
        return _lecturers;
    }

// Delete
    public static bool DeleteLecturer(string staffId)
    {
        var lecturer = _lecturers.Find(x => x.StaffId == staffId);
        if (lecturer != null)
        {
            _lecturers.Remove(lecturer);
            return true;
        }

        return false;
    }
}