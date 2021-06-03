using System.Net;

namespace RequesterNetLib.Extensions
{
    public static class StatusCodeExtensions
    {
        public static bool IsOk(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.OK;
        public static bool IsCreated(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.Created;
        public static bool IsAccepted(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.Accepted;
        public static bool IsNoContent(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.NoContent;
        public static bool IsBadRequest(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.BadRequest;
        public static bool IsUnauthorized(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.Unauthorized;
        public static bool IsForbidden(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.Forbidden;
        public static bool IsNotFound(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.NotFound;
        public static bool IsUnprocessableEntity(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.UnprocessableEntity;
        public static bool IsInternalServerError(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.InternalServerError;
        public static bool IsServiceUnavailable(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.ServiceUnavailable;
        public static bool IsGatewayTimeout(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.GatewayTimeout;
        public static bool IsBadGateway(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.BadGateway;
        public static bool IsHttpVersionNotSupported(this HttpStatusCode statusCode) => statusCode == HttpStatusCode.HttpVersionNotSupported;
    }
}
