// Part 1

string[] inputStringArray = Inputs.day8input.Split(Environment.NewLine);
int[,] input = new int[inputStringArray[0].Length, inputStringArray.Length];
for (int i = 0; i < inputStringArray[0].Length; i++)
{
    for (int j = 0; j < inputStringArray.Length; j++)
    {
        input[i, j] = int.Parse(inputStringArray[i][j].ToString());
    }
}
int sum = 0;
for (int i = 0; i < input.GetLength(0); i++)
{
    for (int j = 0; j < input.GetLength(1); j++)
    {
        if (j == 0 || j == input.GetLength(1) 
            || i == 0 || i == input.GetLength(0))
        {
            sum++;
            continue;
        }
        bool visible = true;
        int current = input[i, j];
        // Left
        for (int l = j - 1; l >= 0; l--)
        {
            if (current <= input[i, l])
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            sum++;
            continue;
        }
        //Right
        for (int r = j + 1; r < input.GetLength(0); r++)
        {
            if (current <= input[i, r])
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            sum++;
            continue;
        }
        //Top
        for (int t = i - 1; t >= 0; t--)
        {
            if (current <= input[t, j])
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            sum++;
            continue;
        }
        //Bottom
        for (int b = i + 1; b < input.GetLength(1); b++)
        {
            if (current <= input[b, j])
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            sum++;
        }
    }
}
Console.WriteLine(sum);

// Part 2

string[] inputStringArray = Inputs.day8input.Split(Environment.NewLine);
int[,] input = new int[inputStringArray[0].Length, inputStringArray.Length];
for (int i = 0; i < inputStringArray.Length; i++)
{
    for (int j = 0; j < inputStringArray[0].Length; j++)
    {
        input[i, j] = int.Parse(inputStringArray[i][j].ToString());
    }
}
List<int> list = new List<int>();
for (int row = 0; row < input.GetLength(0); row++)
{
    for (int col = 0; col < input.GetLength(1); col++)
    {
        int[] intArr = new int[5] { input[row, col], 0, 0, 0, 0};
        for (int l = col - 1; l >= 0; l--)
        {
            if (intArr[0] > input[row, l]) { intArr[1]++; }
            else { intArr[1]++; break; }
        }
        for (int r = col + 1; r < input.GetLength(0); r++)
        {
            if (intArr[0] > input[row, r]) { intArr[2]++; }
            else { intArr[2]++; break; }
        }
        for (int t = row - 1; t >= 0; t--)
        {
            if (intArr[0] > input[t, col]) { intArr[3]++; }
            else { intArr[3]++; break; }
        }
        for (int b = row + 1; b < input.GetLength(1); b++)
        {
            if (intArr[0] > input[b, col]) { intArr[4]++; }
            else { intArr[4]++; break; }
        }       
        list.Add(intArr[1] * intArr[2] * intArr[3] * intArr[4]);
    }
}
Console.WriteLine(list.Max());
// 595080
