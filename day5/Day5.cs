using System.Text;
namespace AoC.Day4;
public class Day5 : AocDay
{
    public override int Day => 5;
    IEnumerable<IEnumerable<IEnumerable<long>>> maps;
    public override void Run(int part)
	{
        var input = File.ReadAllText($"{GetType().Name.ToLower()}/input");
        var inputs = input.Trim().Split("\n\n").ToList();
        var seeds = inputs[0].Split(':')[1].Trim().Split(' ').Select(seedInput =>
            long.Parse(seedInput)
        );
        inputs.RemoveAt(0);
        maps = inputs.Select(mapInput =>
            mapInput.Split(':')[1].Trim().Split('\n').Select(rangeInput =>
                rangeInput.Trim().Split(' ').Select(numInput =>
                    long.Parse(numInput)
                )
            )
        );
        long? lowestMappedSeed = null;
        foreach(var seed in seeds)
        {
            var mappedSeed = MapSeed(seed);
            if (lowestMappedSeed is not long lowest)
                lowestMappedSeed = mappedSeed;
            else
                lowestMappedSeed = Math.Min(lowest, mappedSeed);
                
        }
        Console.WriteLine(lowestMappedSeed);
    }
    long MapSeed(long seed)
    {
        foreach(var map in maps)
        {
            try
            {
                foreach(var range in map)
                {
                    using var rangeEnum = range.GetEnumerator();
                    var ex = new InvalidOperationException("Collection does not have enough elements.");
                    var dstStart = rangeEnum.MoveNext() ? rangeEnum.Current : throw ex;
                    var srcStart = rangeEnum.MoveNext() ? rangeEnum.Current : throw ex;
                    var numRange = rangeEnum.MoveNext() ? rangeEnum.Current : throw ex;
                    if (seed >= srcStart && seed < srcStart + numRange)
                        throw new MappingFoundException(seed - srcStart + dstStart); 
                }
            }
            catch(MappingFoundException mapping)
            {
                seed = mapping.newSeed;
            }
        }
        return seed;
    }
}
public class MappingFoundException : Exception
{
    public long newSeed;
    public MappingFoundException(long newSeed)
    {
        this.newSeed = newSeed;
    }
}