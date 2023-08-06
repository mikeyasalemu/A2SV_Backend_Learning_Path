using System.Runtime.Serialization;

public class Student
{
    public string? Name { get; set;}
    public int Age { get; set;} 
    [DataMember]
    public readonly string RollNumber;
    public double Grade { get; set;}
     public Student(string rollNumber)
    {
        RollNumber = rollNumber;
    }
}