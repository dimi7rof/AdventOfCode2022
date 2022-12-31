// Part1

string[] inputStringArray = Inputs.day9input.Split(Environment.NewLine);
string[,] field = new string[999, 999];
int[] posH = new int[2] { (field.GetLength(0) / 2), (field.GetLength(1) / 2) };
int[] posT = new int[2] { (field.GetLength(0) / 2), (field.GetLength(1) / 2) };
int[] lastH = new int[2] { (field.GetLength(0) / 2), (field.GetLength(1) / 2) };
int[] lastT = new int[2] { (field.GetLength(0) / 2), (field.GetLength(1) / 2) };

var set = new HashSet<(int, int)>();

for (int i = 0; i < inputStringArray.Length; i++)
{
    string[] arr = inputStringArray[i].Split(" ");
    string motion = arr[0];
    int steps = int.Parse(arr[1]);
    for (int step = 1; step <= steps; step++)
    {
        if (motion == "R")
        {
            posH[1]++;
            if ((posH[1] - posT[1]) == 2)
            {
                posT[1]++;
                posT[0] = posH[0];
            }
        }
        else if (motion == "L")
        {
            posH[1]--;
            if ((posH[1] - posT[1]) == -2)
            {
                posT[1]--;
                posT[0] = posH[0];
            }
        }
        else if (motion == "D")
        {
            posH[0]++;
            if ((posH[0] - posT[0]) == 2)
            {
                posT[0]++;
                posT[1] = posH[1];
            }
        }
        else if (motion == "U")
        {
            posH[0]--;
            if ((posH[0] - posT[0]) == -2)
            {
                posT[0]--;
                posT[1] = posH[1];
            }
        }
        if (lastH[0] != posH[0] || lastH[1] != posH[1])
        {
            field[lastH[0], lastH[1]] = ".";
            lastH[0] = posH[0];
            lastH[1] = posH[1];
        }
        if (lastT[0] != posT[0] || lastT[1] != posT[1])
        {
            if (!set.Contains((lastT[0], lastT[1])))
            {
                set.Add((lastT[0], lastT[1]));
            }
            lastT[0] = posT[0];
            lastT[1] = posT[1];
        }
    }
    
    field[(field.GetLength(0) / 2), (field.GetLength(1) / 2)] = "s";
    field[posT[0], posT[1]] = "T";
    field[posH[0], posH[1]] = "H";
  
    Console.WriteLine(set.Count + 1);    
}

// Part2

int trackTail(string[] input, int length = 2)
{
    var motions = input.Select(x =>
    {
        var split = x.Split(" ");
        return (
            split[0] switch
            {
                "L" => (-1, 0),
                "R" => (1, 0),
                "U" => (0, -1),
                "D" => (0, 1),
                _ => (0, 0)
            },
            int.Parse(split[1])
        );
    });

    var rope = new (int, int)[length];
    var tail = new HashSet<(int, int)>();

    foreach (var m in motions)
    {
        ((int dx, int dy), int steps) = m;
        for (var i = 0; i < steps; i++)
        {
            (int x, int y) = rope[0];
            rope[0] = (x + dx, y + dy);

            for (var j = 1; j < rope.Length; j++)
            {
                (int prevX, int prevY) = rope[j - 1];
                (int currX, int currY) = rope[j];
                (int distX, int distY) = (prevX - currX, prevY - currY);

                if (Math.Abs(distX) > 1 || Math.Abs(distY) > 1)
                {
                    rope[j] = (currX + Math.Sign(distX), currY + Math.Sign(distY));
                }
            }
            tail.Add(rope.Last());
        }
    }
    return tail.Count;
}

var result = trackTail(inputStringArray, 10);
Console.WriteLine(result);
