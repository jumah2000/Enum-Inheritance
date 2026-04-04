using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Services.StudentService;

namespace ConsoleAppCleanProject.UserHandler;

public static class StudentUserInputHandler
{
    public static void Run()
    {
        
        while (true)
        {
            Console.WriteLine("Admin Login");
            Console.WriteLine("----------");
            
            Console.Write("enter your userId :");
            var adminId = Console.ReadLine();
            Console.WriteLine("----------");
            
            Console.Write("enter your password :");
            var adminpass = Console.ReadLine();
         
            if(!(StudentServiceRepository.ValidateAdmin(adminId, adminpass)))
            {
                Console.WriteLine("Invalid Credentials");
                return;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Login Successful");
            Console.WriteLine("-------------------------");

            var running = true;
            while (running)
            {
                Console.WriteLine("enter 1 to add student \n enter 2 to Get studentby ID. \n enter 3 to view all students\n 4 -- Exit");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("-------------------------");
                        
                        Console.Write("Enter your age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-------------------------");
                        
                        Console.Write("Enter your address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-------------------------");
                        
                        Console.WriteLine ("Select Gender\n 1. Male.\n 2. Female");
                        var genderchoice = Console.ReadLine();
                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            return;
                        }
                        
                        // Add Student 
                    StudentServiceRepository.AddStudent(name ,age , address,  newGender);
                        break;
                    
                    case "2":
                        
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get student by ID");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Enter student ID: ");
                        var studentId = Console.ReadLine();
                        StudentServiceRepository.GetStudentbyId(studentId);
                        break;
                    
                    case "3":
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Get all students");
                        Console.WriteLine("-------------------------");
                        StudentServiceRepository.GetAllStudents();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                    
                    
                }
            }

        }
    }
}