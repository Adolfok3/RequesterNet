using System.Collections.Generic;

namespace RequesterNetLib.Options
{
    public class RequesterNetOptions
    {
        public string UrlBase { get; set; }
        public Dictionary<string, string> DefaultHeaders { get; set; }
        public uint DefaultTimeoutInSeconds { get; set; } = 30;
    }
}
