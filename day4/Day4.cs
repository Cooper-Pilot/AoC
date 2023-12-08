using System.Text;
namespace AoC.Day4;
public class Day4 : AocDay
{
    public override int GetDay() => 4;
    public override void Run(int part)
	{
        var lines = File.ReadAllLines("day4/input");
        int sum = 0;
        List<int> timesToCopy = new();
        foreach(var line in lines)
        {
            var data = line.Split(':')[1].Split('|');
            var cardNums = data[0].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s));
            var winningNums = data[1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s));
            var matchCount = cardNums.Where(i => winningNums.Contains(i)).Count();
            if (part == 1 && matchCount > 0)
                sum += (int)Math.Pow(2, matchCount - 1);
            if (part != 2)
                continue;
            sum += 1 + timesToCopy.Count;
            for(int i = timesToCopy.Count - 1; i >= 0; i--)
            {
                timesToCopy[i]--;
                if (timesToCopy[i] == 0)
                    timesToCopy.RemoveAt(i);
            }
            if (matchCount > 0)
                timesToCopy.Add(matchCount);
        }
        Console.WriteLine(sum);
    }
}