using System.Text;

public class Day3 : AocDay
{
    public override int GetDay() => 3;
    public override void Run(int part)
	{
        var lines = File.ReadAllLines("day3/input");
        StringBuilder id = new();
        List<Part> parts = new();
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if (!char.IsDigit(c))
                {
                    if (id.Length > 0)
                    {
                        parts.Add(new(int.Parse(id.ToString()), x - id.Length, y));
                        id.Clear();
                    }
                    continue;
                }
                id.Append(c);
            }
        }
    }
}
public record Part(int id, int x, int y);