var lines = File.ReadAllLines("input.txt");
var part2 = false;
if (args.Length > 0 && args[0] == "2")
	part2 = true;
int sum = 0;
List<(string, char)> digitWords =
[
	("one",	 	'1'),
	("two",	 	'2'),
	("three",	'3'),
	("four",	'4'),
	("five",	'5'),
	("six",	 	'6'),
	("seven",	'7'),
	("eight",	'8'),
	("nine",	'9'),
];
foreach(var line in lines)
{
	List<(int, char)> digits = [];
	if (part2)
	{
		foreach((var word, var digit) in digitWords)
		{
			int index = 0;
			while((index = line[index..].IndexOf(word)) != -1)
			{
				digits.Add((index, digit));
				index++;
				if (index >= line.Length)
					break;
			}
		}
	}
	for (int i = 0; i < line.Length; i++)
	{
		var c = line[i];
		if (char.IsDigit(c))
			digits.Add((i, c));
	}
	digits = digits.OrderBy(tuple => tuple.Item1).ToList();
	string number = $"{digits.First().Item2}{digits.Last().Item2}";
	sum += int.Parse(number);
}
System.Console.WriteLine(sum);
