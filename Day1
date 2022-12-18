string[] input = day1input2.day1input.Split(Environment.NewLine);
List<int> elvs = new List<int>();
int elv = 0;
foreach (var item in input)
{
    if (item != string.Empty)
    {
        elv += int.Parse(item);
        continue;
    }
    elvs.Add(elv);
    elv = 0;
}
elvs.Sort();
elvs.Reverse();
Console.WriteLine(elvs.Take(3).Sum());
