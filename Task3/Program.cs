// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
<<<<<<< HEAD
// Task1.Main();
Day2T1.Main();
=======
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
public class Program
{
    public static void Main(string[] args){

        StudentList students = new StudentList();

        students.AddStudent("AAA",23,"AA4565",3.4);
        students.AddStudent("BBB",22,"BB4565",2.4);

        students.SearchStudent("AAA");
        
        students.DisplayStudents();
    }
}
>>>>>>> 8c4b418 (task 3)
