class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:\\Users\\Andy\\Desktop\\Caphyon\\ConsoleApp1\\ConsoleApp1\\input.txt";
        var lines = File.ReadAllLines(filePath);

        var stacks = new List<Stack<char>>();
        int lineIndex = 0;

        for (; lineIndex < lines.Length; lineIndex++)
        {
            if (string.IsNullOrWhiteSpace(lines[lineIndex]))
                break;

            var crates = lines[lineIndex].Replace(" ", "").ToCharArray()
                .Reverse();

            stacks.Add(new Stack<char>(crates));
        }

        lineIndex++;
        for (;lineIndex < lines.Length; lineIndex++)
        {
            var parts = lines[lineIndex].Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);


            int numCrates = int.Parse(parts[1]);
            int fromStackIndex = int.Parse(parts[3])-1;
            int toStackIndex = int.Parse(parts[5])-1;

            MoveCrates(numCrates, fromStackIndex, toStackIndex, stacks);
        }

        Console.WriteLine("Order of crates: ");

        Console.WriteLine($"Stack 1:  {GetTopCrate(stacks[0])}");
        Console.WriteLine($"Stack 2:  {GetTopCrate(stacks[1])}");
        Console.WriteLine($"Stack 3:  {GetTopCrate(stacks[2])}");
        Console.WriteLine($"The message for Elves : {GetTopCrate(stacks[0])}{GetTopCrate(stacks[1])}{GetTopCrate(stacks[2])}");
    }


    static void MoveCrates(int numCrates, int fromStackIndex, int toStackIndex, List<Stack<char>> stacks)
    {
        List<char> tempCrates = new List<char>();

        for (int i = 0; i < numCrates; i++)
        {
            if (stacks[fromStackIndex].Count > 0)
            {
                tempCrates.Add(stacks[fromStackIndex].Pop());
            }
        }



        foreach (char crate in tempCrates)
        {
            stacks[toStackIndex].Push(crate);
        }
    }

   

    static char GetTopCrate(Stack<char> stack)
    {
        return stack.Count > 0 ? stack.Peek() : '-';
    }
}
