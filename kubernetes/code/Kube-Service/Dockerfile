FROM  mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
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
COPY ./src/Components/Kube.Service.App/*.csproj ./Components/Kube.Service.App/
COPY ./src/Components/Kube.Service.Domain/*.csproj ./Components/Kube.Service.Domain/
COPY ./src/Components/Kube.Service.Infra/*.csproj ./Components/Kube.Service.Infra/

# Copy microservice hosts:
COPY ./src/Kube.Service.Tests/*.csproj ./Kube.Service.Tests/
COPY ./src/Kube.Service.WebApi/*.csproj ./Kube.Service.WebApi/

# Copy the solution file to restore all projects:
COPY ./src/Kube.Service.sln ./
RUN dotnet restore 
RUN rm -rd /build/src

# # --------------------------------------------------------------------------------------
# # BUILD / TEST / PUBLISH [Stage 2]
# # --------------------------------------------------------------------------------------

# Copy all the source and build the microservice.
COPY ./src ./
RUN dotnet build ./Kube.Service.sln

RUN dotnet test ./Kube.Service.Tests/ --no-build
RUN dotnet publish ./Kube.Service.WebApi/Kube.Service.WebApi.csproj --output ../out --no-build

# --------------------------------------------------------------------------------------
# CREATE IMAGE FOR CONTAINER CREATION [State 3]
# - This state takes the published output from [State 2] and copies them in to a layer
#   belonging to a new Docker image based on the aspnet core base image.  
# - This base image is much smaller since it is a non SDK runtime for asp.net core.
# --------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /microservice

COPY --from=build-env /build/out ./
ENTRYPOINT ["dotnet", "Kube.Service.WebApi.dll"]
