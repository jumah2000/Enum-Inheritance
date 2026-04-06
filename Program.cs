// See https://aka.ms/new-console-template for more information

// using ConsoleAppCleanProject;
// using ConsoleAppCleanProject.Domain;
//
// Console.WriteLine("Hello, World!");

// Let us test the student object

//var student1 = new Student(); // Create a new instance of the Student class
//
// student1.Name = "Barakah";
// student1.Age = 20;
// student1.Gender = Gender.Female;
// student1.Course = "Bachelor of Science in Computer Science";


// var lecture1 = new Lecturer(); // create a new instance of the Lecturer class
//
// lecture1.Name = "Lekan";
// lecture1.Age = 25;
// lecture1.StaffId = "123456";
// lecture1.Gender = Gender.Male;

using ConsoleAppCleanProject.UserHandler;
bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("===================================================");
    Console.WriteLine("================MANAGEMENT SYSTEM==================");
    Console.WriteLine("===================================================");
    Console.WriteLine("\n1. Students\n2. Lecturers\n3. Vendors\n4. Exit");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            StudentUserInputHandler.Run();
            break;
        case "2":
            LecturerUserInputHandler.Run();
            break;
        case "3":
            VendorUserInputHandler.Run();
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid choice");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;
    }
}


