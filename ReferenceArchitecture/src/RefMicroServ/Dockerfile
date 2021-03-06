FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /build/src

LABEL "net-fusion.template.layer"="Contains Restored NuGets"
LABEL "net-fusion.project.url"="https://github.com/grecosoft/NetFusion"

# --------------------------------------------------------------------------------------
# RESTORE [Stage 1]
# --------------------------------------------------------------------------------------
# - This section copies only the solution and projects files used to restore the needed 
#   NuGet packages.  The restored packages are placed in:  /root/.nuget/packages.
#
# - The reason for only copying the solution and project files is so the created layers
#   will be smaller (a restore does not require the source.)  When the next stage is
#   is executed (Build/Test/Publish) for the first time or all subsequent builds,
#   these layers will already exist, and if not changed, will not have to be built.
#
# - These layers would change, for example, if a new Nuget package was added to any
#   of the projects. 
#
# - Since the source of the microservice will change the most often, these layers will
#   be reused and will not have be recreated when the updated source is built. 
# --------------------------------------------------------------------------------------

# Copy microservice components:
COPY ./src/Components/RefMicroServ.App/*.csproj ./Components/RefMicroServ.App/
COPY ./src/Components/RefMicroServ.Domain/*.csproj ./Components/RefMicroServ.Domain/
COPY ./src/Components/RefMicroServ.Infra/*.csproj ./Components/RefMicroServ.Infra/

# Copy microservice hosts:
COPY ./src/RefMicroServ.Tests/*.csproj ./RefMicroServ.Tests/
COPY ./src/RefMicroServ.WebApi/*.csproj ./RefMicroServ.WebApi/

# Copy the solution file to restore all projects:
COPY ./src/RefMicroServ.sln ./
RUN dotnet restore 
RUN rm -rd /build/src

# # --------------------------------------------------------------------------------------
# # BUILD / TEST / PUBLISH [Stage 2]
# # --------------------------------------------------------------------------------------

# Copy all the source and build the microservice.
COPY ./src ./
RUN dotnet build ./RefMicroServ.sln

RUN dotnet test ./RefMicroServ.Tests/ --no-build
RUN dotnet publish ./RefMicroServ.WebApi/RefMicroServ.WebApi.csproj --output ../out --no-build

# --------------------------------------------------------------------------------------
# CREATE IMAGE FOR CONTAINER CREATION [State 3]
# - This state takes the published output from [State 2] and copies them in to a layer
#   belonging to a new Docker image based on the aspnet core base image.  
# - This base image is much smaller since it is a non SDK runtime for asp.net core.
# --------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /microservice

COPY --from=build-env /build/out ./
ENTRYPOINT ["dotnet", "RefMicroServ.WebApi.dll"]
EXPOSE 80