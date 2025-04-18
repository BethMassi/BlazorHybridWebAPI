# BlazorHybridWebAPI
This sample demonstrates how get the weather data from a WebAPI exposed on the Blazor server app which is called from the .NET MAUI client. I started with the .NET MAUI Blazor Hybrid and Web template `maui-blazor-web` and moved the weather generator code from the Weather.razor component to a WeatherService on the server which implements IWeatherService. This interface is injected into the Weather.razor component so that it calls the code directly on the server but uses the httpClient on the .NET MAUI Client.

## IWeatherService.cs in the Shared RCL
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Shared/Services/IWeatherService.cs#L10-L13

## Weather.razor page
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Shared/Pages/Weather.razor#L1-L4

`...UI code is the same...`

https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Shared/Pages/Weather.razor#L41-L50

## WeatherService.cs on the Blazor web app
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Web/Services/WeatherService.cs#L6-L27

## WeatherService.cs on the .NET MAUI client
Note that this class uses an [`HttpClientHelper`](https://github.com/BethMassi/BlazorHybridWebAPI/blob/b6ffd2c9f46a34d7300f3090e6fca15c34c7372d/BlazorHybridWebAPI/BlazorHybridWebAPI/Services/HttpClientHelper.cs#L6) class that manages the HttpClient configuration for use while debugging on simulators and emulators.
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI/Services/WeatherService.cs#L12-L38

## MauiProgram.cs
We need to add the service implementation to the builder:
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI/MauiProgram.cs#L21

## Program.cs on the Blazor web app
We need to add the service implementation to the builder:
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Web/Program.cs#L13

As well as expose the weather API:
https://github.com/BethMassi/BlazorHybridWebAPI/blob/7e773bc7f2b8e1707df469dcd06c9a0ffd27fca9/BlazorHybridWebAPI/BlazorHybridWebAPI.Web/Program.cs#L35-L39



