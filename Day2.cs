//Part1

var results = new Dictionary<string, int>()
{
    { "A X", 4},
    { "A Y", 8},
    { "A Z", 3},
    { "B X", 1},
    { "B Y", 5},
    { "B Z", 9},
    { "C X", 7},
    { "C Y", 2},
    { "C Z", 6}
};

string[] input = Inputs.day2input.Split(Environment.NewLine);

int sum = 0;

foreach (var item in input)
{
    sum += results[item];
}

Console.WriteLine(sum);

//Part2

var results = new Dictionary<string, int>()
{
    { "A X", 3},
    { "A Y", 4},
    { "A Z", 8},
    { "B X", 1},
    { "B Y", 5},
    { "B Z", 9},
    { "C X", 2},
    { "C Y", 6},
    { "C Z", 7}
};
string[] input = Inputs.day2input.Split(Environment.NewLine);
int sum = 0;

foreach (var item in input)
{
    sum += results[item];
}

Console.WriteLine(sum);
