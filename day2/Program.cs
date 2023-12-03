var lines = File.ReadAllLines("input");
Dictionary<string, int> maxCubes = new()
{
	{"red", 12 },
	{"green", 13},
	{"blue", 14},
};
var idSum = 0;
foreach(var line in lines)
{
	var game = line.Split(':');
	var id = game[0].Split(' ')[1];
	var rounds = game[1].Split(';');
	bool gamePossible = true;
	foreach(var round in rounds)
	{
		var colors = round.Split(',');
		foreach(var color in colors)
		{
			var colorSplit = color.Trim().Split(' ');
			var count = colorSplit[0];
			var name = colorSplit[1];
			if (int.Parse(count) > maxCubes[name])
			{
				gamePossible = false;
				break;
			}
		}
		if (!gamePossible)
			break;
	}
	if (gamePossible)
		idSum += int.Parse(id);
}
System.Console.WriteLine(idSum);