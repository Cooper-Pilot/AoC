using System.Text;

public class Day3 : AocDay
{
    public override int Day => 3;
    public override void Run(int part)
	{
        Dictionary<(int x, int y), Gear> gears = new();
        var lines = File.ReadAllLines("day3/input");
        int length = 0;
        List<Location> locations = new();
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0;; x++)
            {
                if (x < line.Length && char.IsDigit(line[x]))
                {
                    length++;
                    continue;
                }
                if (length > 0)
                    locations.Add(new(length, x - length, y));
                length = 0;
                if (x >= line.Length)
                    break;
            }
        }
        int sum = 0;
        foreach(var loc in locations)
        {
            for (int y = loc.y - 1; y <= loc.y + 1; y++)
            {
                if (y < 0 || y >= lines.Length)
                    continue;
                var line = lines[y];
                for (int x = loc.x - 1; x < loc.x + loc.length + 1; x++)
                {
                    if (x < 0 || x >= line.Length)
                        continue;
                    var c = line[x];
                    if (!char.IsDigit(c) && c != '.')
                    {
                        var locLine = lines[loc.y];
                        var str = locLine[loc.x .. (loc.x + loc.length)];
                        var num = int.Parse(str);
                        if (part == 1)
                        {
                            sum += num;
                            goto NextLocation;
                        }
                        if (part == 2 && c == '*')
                        {
                            var gearLoc = (x,y);
                            if (gears.TryGetValue(gearLoc, out var gear))
                            {
                                gear.ratio *= num;
                                gear.numCount++;
                            }
                            else
                                gears.Add(gearLoc, new(num, 1));
                        }
                    }
                }
                NextLocation:;
            }
        }
        if (part == 1)
            Console.WriteLine(sum);
        if (part == 2)
        {
            foreach(var gear in gears.Values)
            {
                if (gear.numCount == 2)
                    sum += gear.ratio;
                //Console.WriteLine($"x:{pos.x},y:{pos.y},r:{ratio}");
            }
            Console.WriteLine(sum);
        }
    }
}
public record Location(int length, int x, int y);
public class Gear
{
    public int ratio, numCount;

    public Gear(int ratio, int numCount)
    {
        this.ratio = ratio;
        this.numCount = numCount;
    }
}