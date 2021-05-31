using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequesterNetLib.Interfaces
{
    public interface IRequesterNet
    {
        Task<HttpResponseMessage> GetAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, TimeSpan? timeout = null);
        Task<HttpResponseMessage> PostAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null);
        Task<HttpResponseMessage> PutAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null);
        Task<HttpResponseMessage> PatchAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null);
        Task<HttpResponseMessage> DeleteAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, TimeSpan? timeout = null);
    }
}
