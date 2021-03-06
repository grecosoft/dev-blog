FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /build/src

# --------------------------------------------------------------------------------------
# BUILD / TEST / PUBLISH
# --------------------------------------------------------------------------------------

COPY ./src ./
RUN dotnet build ./RefMicroServ.sln

RUN dotnet test ./RefMicroServ.Tests/ --no-build
RUN dotnet publish ./RefMicroServ.WebApi/RefMicroServ.WebApi.csproj --output ../out --no-build

# --------------------------------------------------------------------------------------
# CREATE IMAGE FOR CONTAINER CREATION
# --------------------------------------------------------------------------------------

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /microservice

COPY --from=build-env /build/out ./
ENTRYPOINT ["dotnet", "RefMicroServ.WebApi.dll"]
EXPOSE 80
