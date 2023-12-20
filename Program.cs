Dictionary<int, AocDay> aocDays = new();
var types =
    from assembly in AppDomain.CurrentDomain.GetAssemblies()
    from type in assembly.GetTypes()
    where type.IsSubclassOf(typeof(AocDay))
    select type;
foreach (var type in types)
{
    AocDay aocDay = (AocDay)Activator.CreateInstance(type)!;
    try
    {
        var _day = aocDay.Day;
        if (aocDays.TryGetValue(_day, out var foundDay))
        {
            Console.Error.WriteLine($"Duplicate GetDay() returns detected: \"{_day}\" from {foundDay.GetType().Name} and {aocDay.GetType().Name}");
            return;
        }
        aocDays.Add(_day, aocDay);
    }
    catch (NotImplementedException)
    {
        Console.Error.WriteLine($"\"{type.Name}\" has not implemented \"{nameof(aocDay.Day)}\", skipping...");
    }
}
int day = 1, part = 1;
try
{
    if (args.Length > 2)
        throw new ArgumentException("Too many args, expected 2 or fewer");
    if (args.Length > 0 && !int.TryParse(args[0], out day))
        throw new ArgumentException($"First arg \"{args[0]}\" must be an integer");
    if (args.Length == 2 && !int.TryParse(args[1], out part))
        throw new ArgumentException($"Second arg \"{args[1]}\" must be an integer");
    if (!aocDays.ContainsKey(day))
        throw new ArgumentException($"First arg \"{day}\" err: day does not exist");
    if (part < 1 || part > 2)
        throw new ArgumentException($"Second arg \"{part}\" must be 1 or 2");
    Console.WriteLine($"Starting day {day} part {part}");
    aocDays[day].Run(part);
}
catch (Exception e) when (e is NotImplementedException || 
                          e is ArgumentException)
{
    Console.Error.WriteLine(e.Message);
}