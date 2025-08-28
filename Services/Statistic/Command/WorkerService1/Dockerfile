# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Services/Statistic/Command/WorkerService1/WorkerService1.csproj, Services/Statistic/Command/WorkerService1/
COPY Services/Statistic/Command/Infrastructure.EventStore/Infrastructure.EventStore.csproj, Services/Statistic/Command/Infrastructure.EventStore/
COPY Services/Statistic/Command/Application/Application.csproj, Services/Statistic/Command/Application/
COPY Services/Statistic/Command/Domain/Domain.csproj, Services/Statistic/Command/Domain/
COPY Contracts/Contracts.csproj, Contracts/
COPY Services/Statistic/Command/Infrastructure.MessageBus/Infrastructure.MessageBus.csproj, Services/Statistic/Command/Infrastructure.MessageBus/

RUN dotnet restore Services/Statistic/Command/WorkerService1/WorkerService1.csproj

COPY Services/Statistic/Command/WorkerService1/, Services/Statistic/Command/WorkerService1/
COPY Services/Statistic/Command/Infrastructure.EventStore/, Services/Statistic/Command/Infrastructure.EventStore/
COPY Services/Statistic/Command/Application/, Services/Statistic/Command/Application/
COPY Services/Statistic/Command/Domain/, Services/Statistic/Command/Domain/
COPY Contracts/, Contracts/
COPY Services/Statistic/Command/Infrastructure.MessageBus/, Services/Statistic/Command/Infrastructure.MessageBus/

WORKDIR /src/Services/Statistic/Command/WorkerService1
RUN dotnet build -c Release --no-restore -v m -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish WorkerService1.csproj -c Release -o /app/publish /p:UseAppHost=false


# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService1.dll"]