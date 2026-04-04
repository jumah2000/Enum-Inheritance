namespace ConsoleAppCleanProject.Domain;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
  
}

public enum Gender
{
    Male = 1  ,
    Female = 2
}


// Inheritance 
// This is a concept in OOP, that allows one class to reuse properties and methods of another class.
// This is where we have Child class inheriting from Parent class.

// Enum 
// This is a data type that represents a set of named constants.