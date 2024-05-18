namespace StoreApp.Infastructure.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue  //gelen requestin QueryString ifadesi var mı diye sorguluyor?
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString(); //eğer querystring ifadesi bulunuyorsa isteğin yolunu dönüş yapmış oluyor.
        }
    }
}
