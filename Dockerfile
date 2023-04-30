FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
ENV ASPNETCORE_URLS "http://+80"

COPY dist .

ENTRYPOINT ["dotnet", "WebApi.dll"]