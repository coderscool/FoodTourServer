# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Services/Account/Command/WorkerService1/WorkerService1.csproj, Services/Account/Command/WorkerService1/
COPY Services/Account/Command/Infrastructure.EventStore/Infrastructure.EventStore.csproj, Services/Account/Command/Infrastructure.EventStore/
COPY Services/Account/Command/Application/Application.csproj, Services/Account/Command/Application/
COPY Services/Account/Command/Domain/Domain.csproj, Services/Account/Command/Domain/
COPY Contracts/Contracts.csproj, Contracts/
COPY Services/Account/Command/Infrastructure.MessageBus/Infrastructure.MessageBus.csproj, Services/Account/Command/Infrastructure.MessageBus/

RUN dotnet restore Services/Account/Command/WorkerService1/WorkerService1.csproj

COPY Services/Account/Command/WorkerService1/, Services/Account/Command/WorkerService1/
COPY Services/Account/Command/Infrastructure.EventStore/, Services/Account/Command/Infrastructure.EventStore/
COPY Services/Account/Command/Application/, Services/Account/Command/Application/
COPY Services/Account/Command/Domain/, Services/Account/Command/Domain/
COPY Contracts/, Contracts/
COPY Services/Account/Command/Infrastructure.MessageBus/, Services/Account/Command/Infrastructure.MessageBus/

WORKDIR /src/Services/Account/Command/WorkerService1
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