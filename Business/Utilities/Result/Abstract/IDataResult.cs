namespace Business.Utilities.Result.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
