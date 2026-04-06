namespace ConsoleAppCleanProject.UserHandler;

public static class AppMenu
{
    public static void Run()
    {
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


    }
}