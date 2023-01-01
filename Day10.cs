// Part1

string[] inputStringArray = Inputs.day10input.Split(Environment.NewLine);
int cycle = 0;
int X = 1;
int[] signal = new int[] { 20, 60, 100, 140, 180, 220 };
for (int line = 0; line < inputStringArray.Length; line++)
{
    string[] cmd = inputStringArray[line].Split(" ");
	if (cmd[0] == "noop")
	{
		cycle++;
		signal = checkSignal(signal, cycle, X);
	}
	else
	{
		cycle++;
        signal = checkSignal(signal, cycle, X);
        cycle++;
        signal = checkSignal(signal, cycle, X);
        X += int.Parse(cmd[1]);
	}
}
Console.WriteLine(signal.Sum());
int[] checkSignal(int[] singal, int cycle, int X)
{
    for (int s = 0; s < signal.Length; s++)
    {
        if (cycle == signal[s])
        {
            signal[s] *= X;
        }
    }
    return singal;
}

// Part2

string[] inputStringArray = Inputs.day10input.Split(Environment.NewLine);
int cycle = 0;
int X = 1;
int[] signal = new int[] { 20, 60, 100, 140, 180, 220 };
string[] message = new string[246];
for (int line = 0; line < inputStringArray.Length; line++)
{
    string[] cmd = inputStringArray[line].Split(" ");
	if (cmd[0] == "noop")
    {
        message = draw(message, cycle, X);
        cycle++;
		signal = checkSignal(signal, cycle, X);
	}
	else
    {
        message = draw(message, cycle, X);
        cycle++;
        signal = checkSignal(signal, cycle, X);
        message = draw(message, cycle, X);
        cycle++;
        signal = checkSignal(signal, cycle, X);
        X += int.Parse(cmd[1]);
	}
}
for (int i = 0; i < message.Length; i++)
{
    if (i % 40 == 0)
    {
        Console.WriteLine();
    }
    Console.Write(message[i]);
}
string[] draw(string[] message, int cycle, int X)
{
    if (X == cycle % 40 || X == (cycle % 40) - 1 || X == (cycle % 40) + 1)
    {
        message[cycle] = "#";
    }
    else
    {
        message[cycle] = ".";
    }
    return message;
}
int[] checkSignal(int[] singal, int cycle, int X)
{
    for (int s = 0; s < signal.Length; s++)
    {
        if (cycle == signal[s])
        {
            signal[s] *= X;
        }
    }
    return singal;
}
