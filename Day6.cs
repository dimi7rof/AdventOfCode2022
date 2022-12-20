// Part 1

string input = Inputs.day6input;
int markerLenght = 4;
for (int i = 0; i < input.Length - markerLenght; i++)
{
    if (input.Substring(i, markerLenght).ToCharArray().Distinct().Count() == markerLenght)
    {
        Console.WriteLine(i + markerLenght);
        return;
    }
}

//Part2

int markerLenght = 14;
