using JustInTime.BLL.Enums;

namespace JustInTime.BLL.Responses;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; }
    
    public StatusCode StatusCode { get; set; }
    
    public T Data { get;}
}

public interface IBaseResponse<T>
{
    T Data { get; }
}