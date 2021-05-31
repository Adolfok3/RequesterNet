using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using RequesterNetLib.Interfaces;
using RequesterNetLib.Options;

namespace RequesterNetLib
{
    public sealed class RequesterNet : IRequesterNet
    {
        private readonly string _urlBase;
        private readonly Dictionary<string, string> _defaultHeaders;

        public RequesterNet()
        {
        }

        public RequesterNet(IOptions<RequesterNetOptions> options)
        {
            _urlBase = options.Value.UrlBase;
            _defaultHeaders = options.Value.DefaultHeaders;
        }

        public async Task<HttpResponseMessage> GetAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, TimeSpan? timeout = null)
        {
            var http = GetHttp(url, parameters, headers, null, timeout, out var finalUrl, out _);

            return await http.GetAsync(finalUrl);
        }

        public async Task<HttpResponseMessage> PostAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null)
        {
            var http = GetHttp(url, parameters, headers, body, timeout, out var finalUrl, out var content);
            return await http.PostAsync(finalUrl, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null)
        {
            var http = GetHttp(url, parameters, headers, body, timeout, out var finalUrl, out var content);
            return await http.PutAsync(finalUrl, content);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, object body = null, TimeSpan? timeout = null)
        {
            var http = GetHttp(url, parameters, headers, body, timeout, out var finalUrl, out var content);
            return await http.PatchAsync(finalUrl, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url = null, Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null, TimeSpan? timeout = null)
        {
            var http = GetHttp(url, parameters, headers, null, timeout, out var finalUrl, out _);
            return await http.DeleteAsync(finalUrl);
        }

        private HttpClient GetHttp(string url, Dictionary<string, string> parameters, Dictionary<string, string> headers, object body, TimeSpan? timeout,
            out string finalUrl, out StringContent content)
        {
            var http = new HttpClient();
            SetHeaders(ref http, headers);
            SetTimeout(ref http, timeout);
            finalUrl = MountQueryString(url, parameters);
            content = GetContent(body);

            return http;
        }

        private StringContent GetContent(object body)
        {
            var json = JsonSerializer.Serialize(body);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        internal string MountQueryString(string url, Dictionary<string, string> parameters)
        {
            var finalUrl = GetFinalUrl(url);
            if (parameters == null || !parameters.Any())
                return finalUrl;
            
            var uri = HttpUtility.ParseQueryString(string.Empty);
            foreach (var (key, value) in parameters)
            {
                uri.Add(key, value);
            }

            return $"{finalUrl}?{uri}";
        }

        private string GetFinalUrl(string url)
        {
            if (string.IsNullOrEmpty(_urlBase))
                return new Uri(url).ToString();

            return string.IsNullOrEmpty(url) ? _urlBase : new Uri($"{_urlBase}/{url}").ToString();
        }

        internal void SetHeaders(ref HttpClient http, Dictionary<string, string> headers)
        {
            headers ??= new Dictionary<string, string>();

            if (_defaultHeaders != null)
                headers = _defaultHeaders.Concat(headers).ToDictionary(f => f.Key, f => f.Value);
            
            foreach (var (key, value) in headers)
            {
                http.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
            }
        }

        internal void SetTimeout(ref HttpClient http, TimeSpan? timeout)
        {
            if (timeout.HasValue)
            {
                http.Timeout = timeout.Value;
                return;
            }

            http.Timeout = TimeSpan.FromSeconds(30);
        }
    }
}
