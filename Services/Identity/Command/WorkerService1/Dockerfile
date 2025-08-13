# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Identity/Command/WorkerService1/WorkerService1.csproj", "Services/Identity/Command/WorkerService1/"]
COPY ["Services/Identity/Command/Infrastructure.EventStore/Infrastructure.EventStore.csproj", "Services/Identity/Command/Infrastructure.EventStore/"]
COPY ["Services/Identity/Command/Application/Application.csproj", "Services/Identity/Command/Application/"]
COPY ["Services/Identity/Command/Domain/Domain.csproj", "Services/Identity/Command/Domain/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Services/Identity/Command/Infrastructure.MessageBus/Infrastructure.MessageBus.csproj", "Services/Identity/Command/Infrastructure.MessageBus/"]
RUN dotnet restore "./Services/Identity/Command/WorkerService1/WorkerService1.csproj"
COPY . .
WORKDIR "/src/Services/Identity/Command/WorkerService1"
RUN dotnet build "./WorkerService1.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WorkerService1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService1.dll"]