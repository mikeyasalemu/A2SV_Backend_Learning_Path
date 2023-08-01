class Task3
{
    public static void Main()
    {
         Console.WriteLine("Please write your test case!");
         string? input = Console.ReadLine();
         string? test = "";

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid input. Please enter a non-null string.");
            return; 
        }   

         foreach (char ch in input)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    test += ch;
                }
            }
         
         int left = 0, right = (test.Length) -1;

         bool palindrom = true;

         while(left < right)
            {
                if (test[left] != test[right])
                {
                    Console.WriteLine($"{test[left]} , {test[right]}");
                    palindrom = false;
                    break;
                }
                left++;
                right--;
            }

        if (palindrom)
        {
                Console.WriteLine("The input is Palindrom!!!");
        }
        else
        {
                Console.WriteLine($"{test} The input is NOT Palindrom");
        }
         

    }
}