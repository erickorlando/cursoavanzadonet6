namespace GalaxyApp.Dto.Response;

public class BaseResponse
{
    public bool Exito { get; set; }

    public string? MensajeError { get; set; }
}

public class BaseResponseGeneric<T> : BaseResponse
{
    public T? Data { get; set; }
}

public class BaseResponseList<T> : BaseResponse
{
    public ICollection<T>? Data { get; set; }

    public int CantidadPaginas { get; set; }
}