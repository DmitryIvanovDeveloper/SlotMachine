namespace SlotMachine.Infrastructure.Repository.Adapters.Responses
{
    public interface IResponse<T>
    {
        string Status { get; }
        public T Data { get; }
    }
}

