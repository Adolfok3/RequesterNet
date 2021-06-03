using RequesterNetLib.Extensions;
using System.Net;
using Xunit;

namespace RequesterNetLib.Test
{
    public class StatusCodeExtensionsTest
    {
        [Fact]
        public void StatusCodeShouldBeIsOk()
        {
            const HttpStatusCode status = HttpStatusCode.OK;
            Assert.True(status.IsOk());
        }

        [Fact]
        public void StatusCodeShouldBeIsCreated()
        {
            const HttpStatusCode status = HttpStatusCode.Created;
            Assert.True(status.IsCreated());
        }

        [Fact]
        public void StatusCodeShouldBeIsAccepted()
        {
            const HttpStatusCode status = HttpStatusCode.Accepted;
            Assert.True(status.IsAccepted());
        }

        [Fact]
        public void StatusCodeShouldBeIsNoContent()
        {
            const HttpStatusCode status = HttpStatusCode.NoContent;
            Assert.True(status.IsNoContent());
        }

        [Fact]
        public void StatusCodeShouldBeIsBadRequest()
        {
            const HttpStatusCode status = HttpStatusCode.BadRequest;
            Assert.True(status.IsBadRequest());
        }

        [Fact]
        public void StatusCodeShouldBeIsUnauthorized()
        {
            const HttpStatusCode status = HttpStatusCode.Unauthorized;
            Assert.True(status.IsUnauthorized());
        }

        [Fact]
        public void StatusCodeShouldBeIsForbidden()
        {
            const HttpStatusCode status = HttpStatusCode.Forbidden;
            Assert.True(status.IsForbidden());
        }

        [Fact]
        public void StatusCodeShouldBeIsNotFound()
        {
            const HttpStatusCode status = HttpStatusCode.NotFound;
            Assert.True(status.IsNotFound());
        }

        [Fact]
        public void StatusCodeShouldBeIsUnprocessableEntity()
        {
            const HttpStatusCode status = HttpStatusCode.UnprocessableEntity;
            Assert.True(status.IsUnprocessableEntity());
        }

        [Fact]
        public void StatusCodeShouldBeIsInternalServerError()
        {
            const HttpStatusCode status = HttpStatusCode.InternalServerError;
            Assert.True(status.IsInternalServerError());
        }

        [Fact]
        public void StatusCodeShouldBeIsServiceUnavailable()
        {
            const HttpStatusCode status = HttpStatusCode.ServiceUnavailable;
            Assert.True(status.IsServiceUnavailable());
        }

        [Fact]
        public void StatusCodeShouldBeIsGatewayTimeout()
        {
            const HttpStatusCode status = HttpStatusCode.GatewayTimeout;
            Assert.True(status.IsGatewayTimeout());
        }

        [Fact]
        public void StatusCodeShouldBeIsBadGateway()
        {
            const HttpStatusCode status = HttpStatusCode.BadGateway;
            Assert.True(status.IsBadGateway());
        }

        [Fact]
        public void StatusCodeShouldBeIsHttpVersionNotSupported()
        {
            const HttpStatusCode status = HttpStatusCode.HttpVersionNotSupported;
            Assert.True(status.IsHttpVersionNotSupported());
        }
    }
}
