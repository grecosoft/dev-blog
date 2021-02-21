FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Demo.WebApi/*.csproj ./Demo.WebApi/
RUN dotnet restore

# copy everything else and build app
COPY Demo.WebApi/. ./Demo.WebApi/
WORKDIR /source/Demo.WebApi
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

ENV ASPNETCORE_URLS=http://*:6760

WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Demo.WebApi.dll"]
EXPOSE 6760
