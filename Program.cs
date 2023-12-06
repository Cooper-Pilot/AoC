using System.Linq;
using System.Runtime.InteropServices;
Dictionary<int, AocDay> aocDays = [];
var types =
from assembly in AppDomain.CurrentDomain.GetAssemblies()
    from type in assembly.GetTypes()
    where type.IsSubclassOf(typeof(AocDay))
    select type;
foreach(var type in types)
{
    if (Activator.CreateInstance(type) is AocDay aocDay)
        aocDays.Add(aocDay.GetDay(), aocDay);
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
catch (ArgumentException e)
{
    Console.Error.WriteLine(e.Message);
}