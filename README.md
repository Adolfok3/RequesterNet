# RequesterNet

![RequesterNet Logo](https://raw.githubusercontent.com/Adolfok3/RequesterNet/main/RequesterNet/Resources/Icon.png)

RequesterNet is a simple and fast REST and HTTP API Client for .NET Core.

## Getting started

First, install the package by executing the following command:
```
PM> Install-Package RequesterNetLib
```

Then, in your ConfigureServices method use:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRequesterNet();
}
```

Or with options:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRequesterNet(opt =>
    {
        opt.UrlBase = "https://example.com",
        opt.DefaultHeaders = new Dictionary<string, string>
        {
            { "Authorization", "Bearer myBearerToken" }
        }
    });
}
```

| Option|Description|Type|Default|
| ------------- |:-------------:| -----:|--------:|
|UrlBase|Set the base url for all calls when using RequesterNet.|string|null|
|DefaultHeaders|Set the default headers for all calls when using RequesterNet.|Dictionary<string, string>|empty|

## Usage

Use the interface IRequesterNet in constructor:
```csharp
private readonly IRequesterNet _requester;

public MyClass(IRequesterNet requester)
{
   _requester = requester;
}
```

### Get
A simple Get request (if a base url is setted only "/endpoint" is required):

```csharp
public void Get()
{
   var response = await _requester.GetAsync("https://example.com/endpoint");
}
```

### Get (parameters and headers)
RequesterNet helps with binding parameters and headers in any request. A simple Get request with custom parameters and headers:

```csharp
public void Get()
{
   var parameters = new Dictionary<string, string>
   {
      { "search", "foo" },
      { "page", "1" }
   };
   var headers = new Dictionary<string, string>
   {
      { "Authorization", "Bearer myBearerToken" },
      { "x-api-key", "myApiKey" }
   };
   var response = await _requester.GetAsync("https://example.com/endpoint", parameters, headers);
   //Final url results in: https://example.com/endpoint?search=foo&page=1
}
```

### Post
Post method follows the same parameters like Get but with a optional body object, example:

```csharp
public void Post()
{
   var parameters = new Dictionary<string, string>
   {
      { "search", "foo" },
      { "page", "1" }
   };
   var headers = new Dictionary<string, string>
   {
      { "Authorization", "Bearer myBearerToken" },
      { "x-api-key", "myApiKey" }
   };
   var body = new
   {
      Username = "myUsername",
      Password = "myPassword"
   };
   var response = await _requester.PostAsync("https://example.com/endpoint", parameters, headers, body);
}
```

### Other methods
RequesterNet has the common http methods, being:

|Method      |Url                 |Parameters        |Headers                |Body                   |
|:----------:|:------------------:|:-----------------:|:--------------------:|:---------------------:|
|GetAsync    |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|PostAsync   |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|PutAsync    |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|PatchAsync  |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|DeleteAsync |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
