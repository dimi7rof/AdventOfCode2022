//Part1

string[] input = Inputs.day5input.Split(Environment.NewLine);

string[] maze = new string[8];

for (int i = 0; i < maze.Length; i++)
{
    maze[i] = input[i];
}

Dictionary<int, Stack<string>> dict = new Dictionary<int, Stack<string>>()
{
    {1, new Stack<string>() },
    {2, new Stack<string>() },
    {3, new Stack<string>() },
    {4, new Stack<string>() },
    {5, new Stack<string>() },
    {6, new Stack<string>() },
    {7, new Stack<string>() },
    {8, new Stack<string>() },
    {9, new Stack<string>() }
};
for (int i = maze.Length - 1; i >= 0; i--)
{
    for (int j = 1; j < 10; j++)
    {
        if (maze[i].Substring(j * 4 - 3, 1) != " ")
        {
            dict[j].Push(maze[i].Substring(j * 4 - 3, 1));
        }
    }
}
for (int i = 10; i < input.Length; i++)
{
    string[] command = input[i].Split();
    int quantity = int.Parse(command[1]);
    int from = int.Parse(command[3]);
    int to = int.Parse(command[5]);
    for (int j = 1; j <= quantity; j++)
    {
        dict[to].Push(dict[from].Pop());
    }   
}
foreach (var item in dict)
{
    Console.Write(item.Value.Peek());
}
//MQTPGLLDN

//Part2

