
using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Services.StudentService;

namespace ConsoleAppCleanProject.UserHandler;

public static class LecturerUserInputHandler
{
    //Entry point for the lecturer management menu
 public static void Run()
    {
        {
            Console.Clear();
            Console.WriteLine("==========LECTURER MANAGEMENT========== ");
            //Ask the user to enter Admin Credentials
            
            Console.Write("Enter Admin ID: ");
            var adminId = Console.ReadLine();
           
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();

            //Validate the admin credential using the service layer
            
            if (LecturerServiceRepository.ValidateAdmin(adminId, password))
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid Admin credentials!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                
                //Go back to ask for credentials
            }

            Console.WriteLine("Login Successful!");
           
            //Variable to control the inner menu loop
            bool running = true;

            while (running)
                
            {
                // Display the menu options
                Console.Clear();
                Console.WriteLine("========LECTURER MENU==========");
                Console.WriteLine("Select option:");
                Console.WriteLine("1. Add Lecturer");
                Console.WriteLine("2. Get Lecturer by ID");
                Console.WriteLine("3. View All Lecturers");
                Console.WriteLine("4. Delete Lecturer");
                Console.WriteLine("5. Exit");
             
                Console.Write("Select option: ");
                var option = Console.ReadLine();
               
                // Handle the user's choice using a switch statement
                switch (option)
                {
                    //Add Lecturer
                    case "1":
                        Console.Write("Enter name: ");
                        var name = Console.ReadLine();

                        Console.Write("Enter age: ");
                        var ageInput = Console.ReadLine();

                        Console.Write("Enter address: ");
                        var address = Console.ReadLine();

                        Console.WriteLine("Select Gender:\n1. Male\n2. Female");
                        var genderChoice = Console.ReadLine();
                        // user input to gender enum safely
                        if (!Enum.TryParse<Gender>(genderChoice, out var gender))
                        {
                            Console.WriteLine("Invalid gender input. Try again.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            continue;
                        }
                        
                        //Add the lecturer using the service layer
                        Console.WriteLine("\n=========NEW STUDENT INCOMING===== ");
                        LecturerServiceRepository.AddLecturer(name, ageInput, address, gender);
                        Console.WriteLine("Lecturer added successfully!");
                        break;
                  
                    //Get student by Id
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n========FETCHING LECTURER BY ID======");
                        Console.Write("Enter Staff ID: ");
                        var id = Console.ReadLine();
                        // store returned value
                        var lecturer = LecturerServiceRepository.GetLecturerById(id);
                        if (lecturer != null)
                        {
                            Console.WriteLine($"\nLecturer Found: {lecturer.Name}.\nAge: {lecturer.Age}.\nAddress: {lecturer.Address}.\nGender: {lecturer.Gender}.\nStaffID: {lecturer.StaffId}.");
                        }
                        else
                        {
                            Console.WriteLine("\nLecturer not found.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        // view all lecturers
                        Console.Clear();
                        Console.WriteLine("======RETRIEVING ALL REGISTERED LECTURERS=======");
                        var allLecturers = LecturerServiceRepository.GetAllLecturers();
                        if (allLecturers.Count == 0)
                        {
                            Console.WriteLine("\nNo lecturers available.");
                        }
                        else
                        {
                            foreach (var l in allLecturers)
                            {
                                Console.WriteLine($"\nName: {l.Name}.\nAge: {l.Age}.\nAddress: {l.Address}.\nGender: {l.Gender}.\nStaffID: {l.StaffId}.");
                            }
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        //Delete Lecturer
                        Console.Clear(); 
                        Console.Write("Enter Lecturer ID to delete: ");
                        var deleteId = Console.ReadLine();
                        Console.WriteLine("=======DELETING LECTURER RECORD======= ");
                        if (LecturerServiceRepository.DeleteLecturer(deleteId))
                        {
                            Console.WriteLine("\nLecturer deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nLecturer not found.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "5":
                        //Exit to main menu
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}   
