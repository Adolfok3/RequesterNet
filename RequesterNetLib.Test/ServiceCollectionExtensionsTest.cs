using Microsoft.Extensions.DependencyInjection;
using RequesterNetLib.Extensions;
using RequesterNetLib.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace RequesterNetLib.Test
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void AddRequesterNetShouldBeOk()
        {
            var provider = new ServiceCollection()
                .AddRequesterNet()
                .BuildServiceProvider();

            var ex = Record.Exception(() => provider.GetRequiredService<IRequesterNet>());
            Assert.Null(ex);
        }

        [Fact]
        public void AddRequesterNetWithOptionsShouldBeOk()
        {
            var provider = new ServiceCollection()
                .AddRequesterNet(opt =>
                {
                    opt.DefaultHeaders = new Dictionary<string, string>
                    {
                        {"someHeader", "someValue"}
                    };
                    opt.UrlBase = "https://example.com";
                })
                .BuildServiceProvider();

            var ex = Record.Exception(() => provider.GetRequiredService<IRequesterNet>());
            Assert.Null(ex);
        }
    }
}
