// Part1

string[] input = Inputs.day7input.Split(Environment.NewLine);
Dictionary<string, int> folders = new Dictionary<string, int>();
List<string> list = new List<string>();
for (int i = 0; i < input.Length; i++)
{
    string[] row = input[i].Split(" ");
    if (row.Last() == "ls") { continue; }
    if (row[1] == "cd")
    {
        if (row.Last() == "..")
        {
            list.RemoveAt(list.Count - 1);
            continue;
        }
        string folderName = string.Empty;
        foreach (var item in list)
        {
            folderName += item + "/";
        }
        folderName += row.Last().Trim();
        list.Add(folderName);
        if (!folders.ContainsKey(folderName))
        {
            folders[folderName] = 0;
        }
        continue;
    }
    if (row.First() == "dir")
    {
        string folderName = string.Empty;
        foreach (var item in list)
        {
            folderName += item + "/";
        }
        folderName += row.Last().Trim();
        if (!folders.ContainsKey(folderName))
        {
            folders[folderName] = 0;
        }
        continue;
    }
    foreach (var folder in list)
    {
        folders[folder] += int.Parse(row.First());
    }
}
Console.WriteLine(folders.Where(x => x.Value < 100000).Sum(x => x.Value));

// Part 2

int result = folders.Values
    .Where(size => size >= folders["/"] - 40000000)
    .Min();
