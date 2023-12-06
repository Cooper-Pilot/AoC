public class Day1 : AocDay
{
    public override int GetDay() => 1;
    public override void Run(int part)
	{
		var lines = File.ReadAllLines("input.txt");
		var part2 = false;
		if (part == 2)
			part2 = true;
		int sum = 0;
		List<(string, char)> digitStrings =
		[
			("0", '0'),
	        ("1", '1'),
	        ("2", '2'),
	        ("3", '3'),
	        ("4", '4'),
	        ("5", '5'),
	        ("6", '6'),
	        ("7", '7'),
	        ("8", '8'),
	        ("9", '9'),
        ];
		if (part2)
		{
			digitStrings.AddRange([
				("zero",    '0'),
		        ("one",     '1'),
		        ("two",     '2'),
	     	    ("three",   '3'),
		        ("four",    '4'),
		        ("five",    '5'),
		        ("six",     '6'),
		        ("seven",   '7'),
		        ("eight",   '8'),
		        ("nine",    '9'),
	        ]);
		}
		foreach (var line in lines)
		{
			List<(int, char)> digits = [];
			foreach ((var word, var digit) in digitStrings)
			{
				int index = 0;
				while (true)
				{
					int relIndex = line[index..].IndexOf(word);
					if (relIndex == -1)
						break;
					index += relIndex;
					digits.Add((index, digit));
					index++;
					if (index >= line.Length)
						break;
				}
			}
			digits = digits.OrderBy(tuple => tuple.Item1).ToList();
			string number = $"{digits.First().Item2}{digits.Last().Item2}";
			sum += int.Parse(number);
		}
		System.Console.WriteLine(sum);
	}
}