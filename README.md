# RequesterNet

![RequesterNet Logo](https://raw.githubusercontent.com/Adolfok3/RequesterNet/main/RequesterNet/Resources/Icon.png)

[![GithubActions](https://img.shields.io/appveyor/build/Adolfok3/RequesterNet)](https://github.com/Adolfok3/RequesterNet/actions)
[![Tests](https://img.shields.io/appveyor/tests/Adolfok3/RequesterNet)](https://github.com/Adolfok3/RequesterNet/tree/main/RequesterNetLib.Test)
[![Coverage Status](https://coveralls.io/repos/github/Adolfok3/RequesterNet/badge.svg?branch=main)](https://coveralls.io/github/Adolfok3/RequesterNet?branch=main)
[![NuGet](https://buildstats.info/nuget/RequesterNetLib)](https://www.nuget.org/packages/RequesterNetLib)

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
        opt.UrlBase = "https://example.com";
        opt.DefaultTimeoutInSeconds = 100;
        opt.DefaultHeaders = new Dictionary<string, string>
        {
            { "Authorization", "Bearer myBearerToken" }
        };
    });
}
```

| Option|Description|Type|Default|
| ------------- |:-------------:| -----:|--------:|
|UrlBase|Set the base url for all calls when using RequesterNet.|string|null|
|DefaultHeaders|Set the default headers for all calls when using RequesterNet.|Dictionary<string, string>|empty|
|DefaultTimeoutInSeconds|Set the default timeout time in seconds for all calls when using RequesterNet.|uint|30|

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

### All methods
RequesterNet has the common http methods, being:

|Method      |Url                 |Parameters        |Headers                |Body                   |Timeout
|:----------:|:------------------:|:-----------------:|:--------------------:|:---------------------:|:------------:|
|GetAsync    |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:||:heavy_check_mark:|
|PostAsync   |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|PutAsync    |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|PatchAsync  |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|DeleteAsync |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:||:heavy_check_mark:|

## Extensions
RequesterNet has some HttpStatusCode extensions to help check common status codes, example:
```csharp
public void Get()
{
   var response = await _requester.GetAsync("https://example.com/endpoint");
   if (response.StatusCode.IsOk()) { //do stuff }
   if (response.StatusCode.IsBadRequest()) { //do stuff }
   if (response.StatusCode.IsInternalServerError()) { //do stuff }
}
```
All HttpStatusCode extensions:
|Method|Description|Returns|
|:----:|:---------:|:-----:|
|IsOk|Check if status code is 200|bool|
|IsCreated|Check if status code is 201|bool|
|IsAccepted|Check if status code is 202|bool|
|IsNoContent|Check if status code is 204|bool|
|IsBadRequest|Check if status code is 400|bool|
|IsUnauthorized|Check if status code is 401|bool|
|IsForbidden|Check if status code is 403|bool|
|IsNotFound|Check if status code is 404|bool|
|IsRequestTimeout|Check if status code is 408|bool|
|IsUnprocessableEntity|Check if status code is 422|bool|
|IsInternalServerError|Check if status code is 500|bool|
|IsBadGateway|Check if status code is 502|bool|
|IsServiceUnavailable|Check if status code is 503|bool|
|IsGatewayTimeout|Check if status code is 504|bool|
|IsHttpVersionNotSupported|Check if status code is 505|bool|
