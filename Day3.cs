//Part1

string[] rucksack = Inputs.day3input.Split(Environment.NewLine);

int result = 0;

foreach (var item in rucksack)
{
    result += getPriority(findError(item));
}

Console.WriteLine(result);
char findError(string rucksack)
{
    var comp1 = rucksack[0..(rucksack.Length / 2)];
    var comp2 = rucksack[(rucksack.Length / 2)..rucksack.Length];
    return comp1.Intersect(comp2).First();
}
int getPriority(char item) => Char.IsUpper(item) switch
{
    true => (int)item - 38,
    false => (int)item - 96,
};

//Part2

var newResult = rucksack
    .Chunk(3)
    .Select(grp => grp[0]
        .Intersect(grp[1])
        .Intersect(grp[2])
        .First())
    .Select(getPriority)
    .Sum();

Console.WriteLine(newResult);
