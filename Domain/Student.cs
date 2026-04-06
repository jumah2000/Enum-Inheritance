using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Helper;

namespace ConsoleAppCleanProject.Domain;

public class Student : Person
{
   public string StudentId { get; set; }
    public string Course { get; set; }

    public Student(string name, string age, string address, Gender gender)
    {
        Name = name;
        Age = int.Parse(age);
        Address = address;
        Gender = gender;
        StudentId = Utils.GenerateID("STD");
    }
} 