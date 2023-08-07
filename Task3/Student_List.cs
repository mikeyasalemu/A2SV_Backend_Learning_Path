using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
public class StudentList
{
    private List<Student> studentList;

    public StudentList()
    {
        studentList = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        studentList.Add(student);
    }

    public Student SearchStudent(Func<Student, bool> predicate)
    {
        return studentList.FirstOrDefault(predicate);
    }

    public void DisplayAllStudents()
    {
        foreach (var student in studentList)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, " +
                              $"Roll Number: {student.RollNumber}, Grade: {student.Grade}");
        }
    }

    public void SerializeToJson(string filePath)
    {
        string jsonString = JsonConvert.SerializeObject(studentList, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);
    }

    public void DeserializeFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            studentList = JsonConvert.DeserializeObject<List<Student>>(jsonString) ?? new List<Student>();
        }
    }
}
