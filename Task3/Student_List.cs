using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class StudentList
{
    private string fileName = "JsonFile.json";
    public List<Student> studentList;

    public StudentList()
    {
        studentList = new List<Student>();
        DeserializeFromFile();
    }

    private void SerializeToFile()//
    {
        string jsonString = JsonConvert.SerializeObject(studentList, Formatting.Indented);
        File.WriteAllText(fileName, jsonString);
    }

    private void DeserializeFromFile()
    {
        if (!File.Exists(fileName))
        {
            // Create an empty JSON array in the file
            File.WriteAllText(fileName, "[]");
        }

        string jsonString = File.ReadAllText(fileName);
        List<Student> deserializedFile = JsonConvert.DeserializeObject<List<Student>>(jsonString);
        if (deserializedFile != null)
            studentList = deserializedFile;
    }

    public void AddStudent(string name, int age, string rollNumber, double grade)
    {
        studentList.Add(new Student(rollNumber) { Name = name, Age = age, Grade = grade });
        SerializeToFile();
    }

    public void SearchStudent(string name)
    {
        List<Student> students = (from student in studentList where student.Name == name select student).ToList();
        DisplayStudents(students);
    }

    public void DisplayStudents(List<Student>? students = null)
    {
        if (students == null)
            students = studentList;
        Console.WriteLine("STUDENTS LIST:");
        Console.WriteLine("{0,-10}{1,-10}{2,-15}{3}", "NAME", "AGE", "ROLL NUMBER", "GRADE");
        foreach (Student student in students)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-15}{3}", student.Name, student.Age, student.RollNumber, student.Grade);
        }
    }
}
