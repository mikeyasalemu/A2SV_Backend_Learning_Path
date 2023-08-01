class Task2
{
    public static void Main()
    {
        Console.WriteLine("Please Enter the String !");
        string? word = Console.ReadLine();

        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine("Invalid input. Please enter a non-null string.");
            return; 
        }

        Dictionary<char, int> dic = new Dictionary<char, int>();

        foreach (char ch in word)
        {
            if (char.IsLetter(ch))
            {
                if (dic.TryGetValue(ch, out int value))
                {
                    dic[ch] = value + 1;
                }
                else
                {
                    dic[ch] = 1;
                }
            }
        }

        DisplayCharacterCounts(dic);
    }

    public static void DisplayCharacterCounts(Dictionary<char, int> dictionary)
    {
        Console.WriteLine("Character Counts:");
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Character '{kvp.Key}': {kvp.Value}");
        }
    }
}
