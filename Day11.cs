// Part 1

string input = Inputs.day11;
string[] monkies = input.Split("Monkey ", StringSplitOptions.RemoveEmptyEntries);
Dictionary<int, List<int>> monkeyDict = new Dictionary<int, List<int>>();
Dictionary<int, int> monkeyCount = new Dictionary<int, int>();
for (int i = 0; i < 20; i++)
{
    for (int m = 0; m < monkies.Length; m++)
    {
        decimal worry = 0;
        if (i == 0)
        {
            string startReg = Regex.Match(monkies[m], @"Starting items: (.*?)$", RegexOptions.Multiline).Groups[1].Value;
            int[] items = startReg.Split(",").Select(int.Parse).ToArray();
            if (!monkeyDict.ContainsKey(m))
            {
                monkeyDict.Add(m, new List<int>(items));
            }
            else { monkeyDict[m].AddRange(items); }
        }
        foreach (var item in monkeyDict[m])
        {
            string opReg = Regex.Match(monkies[m], @"Operation: new = old (.*?)$", RegexOptions.Multiline).Groups[1].Value;
            string[] operationArr = opReg.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (operationArr[0] == "*")
            {
                if (operationArr[1].StartsWith("old"))
                {
                    worry = item * item;
                }
                else
                {
                    string subStr = operationArr[1][..^1];
                    worry = item * int.Parse(subStr);
                }
            }
            else if (operationArr[0] == "+")
            {
                if (operationArr[1] == "old")
                {
                    worry = item + item;
                }
                else { worry = item + int.Parse(operationArr[1]);}
            }
            worry = Math.Floor(worry / 3);
            int test = int.Parse(Regex.Match(monkies[m], @"Test: divisible by (.*?)$", RegexOptions.Multiline).Groups[1].Value);
            int ifTrue = int.Parse(Regex.Match(monkies[m], @"If true: throw to monkey (.*?)$", RegexOptions.Multiline).Groups[1].Value);
            int ifFalse = int.Parse(Regex.Match(monkies[m], @"If false: throw to monkey (.*?)$", RegexOptions.Multiline).Groups[1].Value);
            int monkeyToAdd = ifFalse;
            if (worry % test == 0) { monkeyToAdd = ifTrue; }
            
                if (!monkeyDict.ContainsKey(monkeyToAdd)) 
                {
                    monkeyDict.Add(monkeyToAdd, new List<int>() { (int)worry });
                }
                else { monkeyDict[monkeyToAdd].Add((int)worry); }
            
            if (!monkeyCount.ContainsKey(m)) 
            { 
                monkeyCount.Add(m, 1);
            }
            else { monkeyCount[m]++; }
        }
        monkeyDict[m].Clear();
    }
}

var result = monkeyCount
    .OrderByDescending(x => x.Value)
    .Take(2)
    .Select(x => x.Value);
Console.WriteLine($"{result.First() * result.Last()}");

// 64032

// Part 2
