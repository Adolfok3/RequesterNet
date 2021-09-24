using RequesterNetLib.Extensions;
using RequesterNetLib.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RequesterNetLib.Test
{
    public class RequesterNetTest
    {
        [Fact]
        public async Task GetAsyncShouldBeOk()
        {
            var requester = new RequesterNet();
            var response = await requester.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task GetAsyncWithUrlBaseShouldBeOk()
        {
            var options = Microsoft.Extensions.Options.Options.Create(new RequesterNetOptions
            {
                UrlBase = "https://jsonplaceholder.typicode.com",
                DefaultTimeoutInSeconds = 25
            });
            var requester = new RequesterNet(options);
            var response = await requester.GetAsync("todos/1");

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task GetAsyncWithDefaultHeadersShouldBeOk()
        {
            var options = Microsoft.Extensions.Options.Options.Create(new RequesterNetOptions
            {
                UrlBase = "https://jsonplaceholder.typicode.com",
                DefaultHeaders = new Dictionary<string, string>
                {
                    { "client_id", Guid.NewGuid().ToString("N") }
                }
            });
            var requester = new RequesterNet(options);
            var response = await requester.GetAsync("todos/1");

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task GetAsyncWithParameterssShouldBeOk()
        {
            var options = Microsoft.Extensions.Options.Options.Create(new RequesterNetOptions
            {
                UrlBase = "https://jsonplaceholder.typicode.com",
                DefaultHeaders = new Dictionary<string, string>
                {
                    { "client_id", Guid.NewGuid().ToString("N") }
                }
            });
            var parameters = new Dictionary<string, string>
            {
                { "page", "1" },
                { "limit", "10" }
            };
            var requester = new RequesterNet(options);
            var response = await requester.GetAsync("todos/1", parameters);

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task PostShouldBeOk()
        {
            var body = new
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
            var requester = new RequesterNet();
            var response = await requester.PostAsync("https://jsonplaceholder.typicode.com/posts", body: body);

            Assert.True(response.StatusCode.IsCreated());
        }

        [Fact]
        public async Task PostWithTimeoutShouldThrowsTaskCanceledException()
        {
            var body = new
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
            var timeout = TimeSpan.FromMilliseconds(1);
            var requester = new RequesterNet();
            await Assert.ThrowsAsync<TaskCanceledException>(() => requester.PostAsync("https://jsonplaceholder.typicode.com/posts", body: body, timeout: timeout));
        }

        [Fact]
        public async Task PutShouldBeOk()
        {
            var body = new
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
            var requester = new RequesterNet();
            var response = await requester.PutAsync("https://jsonplaceholder.typicode.com/posts/1", body: body);

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task PatchShouldBeOk()
        {
            var body = new
            {
                userId = 1,
                id = 1,
                title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };
            var requester = new RequesterNet();
            var response = await requester.PatchAsync("https://jsonplaceholder.typicode.com/posts/1", body: body);

            Assert.True(response.StatusCode.IsOk());
        }

        [Fact]
        public async Task DeleteShouldBeOk()
        {
            var requester = new RequesterNet();
            var response = await requester.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");

            Assert.True(response.StatusCode.IsOk());
        }
    }
}
