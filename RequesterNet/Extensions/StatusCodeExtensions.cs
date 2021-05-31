using System.Net;

namespace RequesterNetLib.Extensions
{
    public static class StatusCodeExtensions
    {
        public static bool IsOk(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.OK;
        }

        public static bool IsCreated(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.Created;
        }

        public static bool IsAccepted(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.Accepted;
        }

        public static bool IsNoContent(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.NoContent;
        }

        public static bool IsBadRequest(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.BadRequest;
        }

        public static bool IsUnauthorized(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.Unauthorized;
        }

        public static bool IsForbidden(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.Forbidden;
        }

        public static bool IsNotFound(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public static bool IsInternalServerError(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.InternalServerError;
        }

        public static bool IsServiceUnavailable(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.ServiceUnavailable;
        }

        public static bool IsGatewayTimeout(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.GatewayTimeout;
        }

        public static bool IsBadGateway(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.BadGateway;
        }

        public static bool IsHttpVersionNotSupported(this HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.HttpVersionNotSupported;
        }
    }
}
