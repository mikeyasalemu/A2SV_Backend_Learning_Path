public class Program
{
    public static void Main(string[] args)
    {
        const string filePath = "studentData.json";
        StudentList studentList = new StudentList();
        bool exit = false;

        Console.WriteLine("Student Management System");
        Console.WriteLine("*************************");

        while (!exit)
        {
            Console.WriteLine("\nWelcome! Please select an option:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Save Data to JSON");
            Console.WriteLine("6. Load Data from JSON");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Roll Number: ");
                    string rollNumber = Console.ReadLine();
                    Console.Write("Enter Grade: ");
                    double grade = double.Parse(Console.ReadLine());

                    var newStudent = new Student(rollNumber) { Name = name, Age = age, Grade = grade };
                    studentList.AddStudent(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;

                case "2":
                    Console.Write("Enter the name to search: ");
                    string searchName = Console.ReadLine();
                    var resultByName = studentList.SearchStudent(s => s.Name == searchName);
                    if (resultByName != null)
                    {
                        Console.WriteLine("Student Found:");
                        Console.WriteLine($"Name: {resultByName.Name}, Age: {resultByName.Age}, " +
                                        $"Roll Number: {resultByName.RollNumber}, Grade: {resultByName.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("No student found with the given name.");
                    }
                    break;

                case "3":
                    Console.Write("Enter the Roll Number to search: ");
                    string searchRollNumber = Console.ReadLine();
                    var resultByRollNumber = studentList.SearchStudent(s => s.RollNumber == searchRollNumber);
                    if (resultByRollNumber != null)
                    {
                        Console.WriteLine("Student Found:");
                        Console.WriteLine($"Name: {resultByRollNumber.Name}, Age: {resultByRollNumber.Age}, " +
                                        $"Roll Number: {resultByRollNumber.RollNumber}, Grade: {resultByRollNumber.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("No student found with the given Roll Number.");
                    }
                    break;

                case "4":
                    Console.WriteLine("All Students:");
                    studentList.DisplayAllStudents();
                    break;

                case "5":
                    studentList.SerializeToJson(filePath);
                    Console.WriteLine("Data saved to JSON successfully.");
                    break;

                case "6":
                    studentList.DeserializeFromJson(filePath);
                    Console.WriteLine("Data loaded from JSON successfully.");
                    break;

                case "7":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
