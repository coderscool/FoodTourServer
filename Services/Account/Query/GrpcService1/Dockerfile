# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Services/Account/Query/GrpcService1/GrpcService1.csproj Services/Account/Query/GrpcService1/
COPY Services/Account/Query/Domain/Infrastructure.EventBus.csproj Services/Account/Query/Domain/
COPY Services/Account/Query/Application/Application.csproj Services/Account/Query/Application/
COPY Contracts/Contracts.csproj Contracts/
COPY Services/Account/Query/Infrastructure.ElasticSearch/Infrastructure.ElasticSearch.csproj Services/Account/Query/Infrastructure.ElasticSearch/
COPY Services/Account/Query/Infrastructure.Projection/Infrastructure.Projection.csproj Services/Account/Query/Infrastructure.Projection/

RUN dotnet restore Services/Account/Query/GrpcService1/GrpcService1.csproj

COPY Services/Account/Query/GrpcService1/ Services/Account/Query/GrpcService1/
COPY Services/Account/Query/Domain/ Services/Account/Query/Domain/
COPY Services/Account/Query/Application/ Services/Account/Query/Application/
COPY Contracts/ Contracts/
COPY Services/Account/Query/Infrastructure.ElasticSearch/ Services/Account/Query/Infrastructure.ElasticSearch/
COPY Services/Account/Query/Infrastructure.Projection/ Services/Account/Query/Infrastructure.Projection/

WORKDIR /src/Services/Account/Query/GrpcService1
RUN dotnet build -c Release --no-restore -v m -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish GrpcService1.csproj -c Release -o /app/publish /p:UseAppHost=false


# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcService1.dll"]