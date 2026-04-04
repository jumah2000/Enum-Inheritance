namespace ConsoleAppCleanProject.Helper;

public static class Utils
{
    public static string GenerateID(string prefix) // prefix is the prefix of the random string
    {
        int randomNumber = new Random().Next(1000, 9999); // Four random numbers between 1000 and 9999
        return $"{prefix}/{randomNumber}";  //  STD/9965, LEC/8877 , VND/1234
    }
    
}

// prefix  == STD
// prefix  == LEC
// prefix = VND