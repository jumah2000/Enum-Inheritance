using ConsoleAppCleanProject.Domain;
using ConsoleAppCleanProject.Domain.Services;

namespace ConsoleAppCleanProject.UserHandler;

public static class VendorUserInputHandler
{
    //Entry point for the student management menu
  public static void Run()
    {
        {
            Console.Clear();
            Console.WriteLine("======VENDOR MANAGEMENT =====");
            
            //Ask the user to enter Admin Credentials

            Console.WriteLine("=======VENDOR MANAGEMENT======");
            Console.Write("Enter Admin ID: ");
            var adminId = Console.ReadLine();
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();


            //Validate the admin credential using the service layer
            if (VendorServiceRepository.ValidateAdmin(adminId, password))
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

            //Variable to control the inner menu loop
            bool running = true;
            while (running)
            {
                // Display the menu options
                Console.Clear();
                Console.WriteLine("======VENDOR MENU =====");
                Console.WriteLine("Select option: ");
                Console.WriteLine("1. Add Vendor");
                Console.WriteLine("2. Get Vendor by ID");
                Console.WriteLine("3. View All Vendors");
                Console.WriteLine("4. Delete Vendor");
                Console.WriteLine("5. Exit");
                
                Console.Write("Select option: ");
                var option = Console.ReadLine();

                // Handle the user's choice using a switch statement
                switch (option)
                {
                    //Add Vendor
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
                        //Add the vendor using the service layer
                       
                        Console.WriteLine("\n=========NEW STUDENT INCOMING===== ");
                        VendorServiceRepository.AddVendor(name, ageInput, address, gender );
                        Console.WriteLine("Vendor added successfully!");
                        break;
                    
                    //Get student by Id
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n========FETCHING VENDOR BY ID======");
                        Console.Write("Enter Vendor ID: ");
                        var id = Console.ReadLine();
                        // store returned value
                        var vendor = VendorServiceRepository.GetVendorById(id);
                        if (vendor != null)
                        {
                            Console.WriteLine($"Vendor Found: {vendor.Name}.\nAge: {vendor.Age}.\nAddress: {vendor.Address}.\nGender: {vendor.Gender}.\nVendorID: {vendor.VendorId}.");
                        }
                        else
                        {
                            Console.WriteLine("Vendor not found.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        // view all students
                        Console.Clear();
                        Console.WriteLine("======RETRIEVING ALL REGISTERED VENDORS=======");
                        var allVendors = VendorServiceRepository.GetAllVendors();
                        if (allVendors.Count == 0)
                        {
                            Console.WriteLine("No vendors available.");
                        }
                        else
                        {
                            foreach (var v in allVendors)
                            {
                                Console.WriteLine($"\nName: {v.Name}.\nAge: {v.Age}.\nAddress: {v.Address}.\nGender: {v.Gender}.\nVendorID: {v.VendorId}.");
                            }
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    
                    case "4":
                        //Delete vendor
                        Console.Clear(); 
                        Console.Write("Enter vendor ID to delete: ");
                        var deleteId = Console.ReadLine();
                        Console.WriteLine("=======DELETING VENDOR RECORD======= ");
                        if (VendorServiceRepository.DeleteVendor(deleteId))
                        {
                            Console.WriteLine("\nVendor deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nVendor not found.");
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
