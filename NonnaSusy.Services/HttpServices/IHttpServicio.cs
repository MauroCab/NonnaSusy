namespace NonnaSusy.Services.HttpServices
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);

        Task<HttpRespuesta<T>> GetTotalProductosPedidos<T>(DateTime fecha);
        Task<HttpRespuesta<object>> Post<T>(string url, T entidad);
    }
}