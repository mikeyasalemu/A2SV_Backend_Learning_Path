    class Task1
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Student Grade Calculator!");

            Console.Write("Enter your name: ");
            string? studentName = Console.ReadLine();

            if (string.IsNullOrEmpty(studentName))
                {
                    Console.WriteLine("Invalid input. Please enter a non-null string.");
                    return; 
                }

        
            int numSubjects;
            do
            {
                Console.Write("Enter the number of subjects you have taken: ");
            } while (!int.TryParse(Console.ReadLine(), out numSubjects) || numSubjects <= 0);

            List<string> subjectNames = new List<string>();
            List<double> grades = new List<double>();

            for (int i = 1; i <= numSubjects; i++)
            {
                Console.Write($"Enter the name of Subject {i}: ");
                string? subjectName;

                do
                {
                    subjectName = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(subjectName));

                subjectNames.Add(subjectName);

                double grade;
                do
                {
                    Console.Write($"Enter the grade obtained in {subjectName}: ");
                } while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100);

                grades.Add(grade);
            }

            double averageGrade = CalculateAverageGrade(grades);

            Console.WriteLine($"\nStudent Name: {studentName}");
            Console.WriteLine("Subject Grades:");

            for (int i = 0; i < numSubjects; i++)
            {
                Console.WriteLine($"{subjectNames[i]}: {grades[i]}");
            }

            Console.WriteLine($"\nAverage Grade: {averageGrade:F2}");
        }

        static double CalculateAverageGrade(List<double> grades)
        {
            double totalMarks = 0;

            foreach (double grade in grades)
            {
                totalMarks += grade;
            }

            return totalMarks / grades.Count;
        }
    }
// }
