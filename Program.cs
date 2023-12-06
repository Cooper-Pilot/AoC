using System.Linq;
var aocDays =
from assembly in AppDomain.CurrentDomain.GetAssemblies()
    from type in assembly.GetTypes()
    where type.IsSubclassOf(typeof(AocDay))
    select type;
foreach(var type in aocDays)
    Console.WriteLine(type.Name);