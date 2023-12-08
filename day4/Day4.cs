using System.Text;
namespace AoC.Day4;
public class Day4 : AocDay
{
    List<int> cardValues = new();
    public override int GetDay() => 4;
    public override void Run(int part)
	{
        var lines = File.ReadAllLines("day4/input");
        int sum = 0;
        foreach(var line in lines)
        {
            var data = line.Split(':')[1].Split('|');
            var cardNums = data[0].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s));
            var winningNums = data[1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s));
            var matchCount = cardNums.Where(i => winningNums.Contains(i)).Count();
            if (part == 1 && matchCount > 0)
                sum += (int)Math.Pow(2, matchCount - 1);
            if (part == 2)
                cardValues.Add(matchCount);
        }
        if (part == 2)
        {
            for(int i = 0; i < cardValues.Count; i++)
            {
                sum += GetTotalValue(i);
            }
        }
        Console.WriteLine(sum);
    }
    public int GetTotalValue(int cardNum)
    {
        int sum = 1;
        int lastCard = cardNum + cardValues[cardNum];
        for (int i = cardNum + 1; i <= lastCard; i++)
        {
            sum += GetTotalValue(i);
        }
        return sum;
    }
}