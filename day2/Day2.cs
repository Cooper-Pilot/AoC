public class Day2 : AocDay
{
    public override int GetDay() => 2;
    public override void Run(int part)
	{
		bool part2 = false;
		if (part == 2)
			part2 = true;
		var lines = File.ReadAllLines("day2/input");
		Dictionary<string, int> maxCubes = new()
{
	{"red", 12},
	{"green", 13},
	{"blue", 14},
};
		var sum = 0;
		foreach (var line in lines)
		{
			var game = line.Split(':');
			var id = game[0].Split(' ')[1];
			var rounds = game[1].Split(';');
			bool gamePossible = true;
			Dictionary<string, int> max = new()
	{
		{"red", 0},
		{"green", 0},
		{"blue", 0},
	};
			foreach (var round in rounds)
			{
				var colors = round.Split(',');
				foreach (var color in colors)
				{
					var colorSplit = color.Trim().Split(' ');
					var count = int.Parse(colorSplit[0]);
					var name = colorSplit[1];
					max[name] = Math.Max(max[name], count);
					if (!part2 && count > maxCubes[name])
					{
						gamePossible = false;
						break;
					}
				}
				if (!part2 && !gamePossible)
					break;
			}
			if (part2)
			{
				var product = max["red"] * max["green"] * max["blue"];
				sum += product;
			}
			else if (gamePossible)
				sum += int.Parse(id);
		}
		System.Console.WriteLine(sum);
	}
}