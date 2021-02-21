FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /microservices/Demo.WebApi

ENV ASPNETCORE_URLS=http://*:6750

COPY ./out ./

ENTRYPOINT ["dotnet", "Demo.WebApi.dll"]
EXPOSE 6750
