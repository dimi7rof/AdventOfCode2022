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

