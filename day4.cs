//Part1

(int[], int[]) getPairs(string pair)
{
    var split = pair.Split(',');
    var elf1 = split[0];
    var elf2 = split[1];

    int[] pairToInt(string section)
    {
        var split = section.Split('-');
        var start = int.Parse(split[0]);
        var end = int.Parse(split[1]);
        return Enumerable
            .Range(start, end - start + 1)
            .ToArray();
    }

    return (pairToInt(elf1), pairToInt(elf2));
}
bool ContainedPair((int[], int[]) pair)
{
    return pair.Item1
        .Intersect(pair.Item2)
        .Count()
        == (pair.Item1.Length < pair.Item2.Length
            ? pair.Item1.Length
            : pair.Item2.Length);
}

   result = inputArr
    .Select(getPairs)
    .Select(ContainedPair)
    .Count(pair => pair == true);

Console.WriteLine(result);

//Part2

bool pairOverlaps((int[], int[]) pair)
{
    return pair.Item1
        .Intersect(pair.Item2)
        .Any();
}
result = inputArr
  .Select(getPairs)
    .Select(pairOverlaps)
    .Count(pair => pair == true);

Console.WriteLine(result);
