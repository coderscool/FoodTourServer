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
COPY Services/Dish/Query/GrpcService1/GrpcService1.csproj Services/Dish/Query/GrpcService1/
COPY Services/Dish/Query/Infrastructure.ElasticSearch/Infrastructure.ElasticSearch.csproj Services/Dish/Query/Infrastructure.ElasticSearch/
COPY Services/Dish/Query/Application/Application.csproj Services/Dish/Query/Application/
COPY Contracts/Contracts.csproj Contracts/
COPY Services/Dish/Query/Infrastructure.EventBus/Infrastructure.EventBus.csproj Services/Dish/Query/Infrastructure.EventBus/
COPY Services/Dish/Query/Infrastructure.Projection/Infrastructure.Projection.csproj Services/Dish/Query/Infrastructure.Projection/

RUN dotnet restore Services/Dish/Query/GrpcService1/GrpcService1.csproj

COPY Services/Dish/Query/GrpcService1/ Services/Dish/Query/GrpcService1/
COPY Services/Dish/Query/Infrastructure.ElasticSearch/ Services/Dish/Query/Infrastructure.ElasticSearch/
COPY Services/Dish/Query/Application/ Services/Dish/Query/Application/
COPY Contracts/ Contracts/
COPY Services/Dish/Query/Infrastructure.EventBus/ Services/Dish/Query/Infrastructure.EventBus/
COPY Services/Dish/Query/Infrastructure.Projection/ Services/Dish/Query/Infrastructure.Projection/

WORKDIR /src/Services/Dish/Query/GrpcService1
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