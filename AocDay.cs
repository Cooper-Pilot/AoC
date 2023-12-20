public class AocDay
{
    public virtual void Run(int part) =>
        throw new NotImplementedException($"{GetType().Name} has not implemented {nameof(Run)}");
    public virtual int Day => throw new NotImplementedException();
}