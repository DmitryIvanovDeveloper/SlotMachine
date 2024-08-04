using SlotMachine.Infrastructure.Repository.Adapters.Responses;

namespace Hare.Infrastructure.Services.Dtos
{
    public class Response<T> : IResponse<T>
    {
        public string Status { get; private set; }
        public T Data { get; private set; }

        public Response(string status, T data)
        {
            Status = status;
            Data = data;
        }
    }
}