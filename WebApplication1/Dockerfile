# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files for restore
COPY Contracts/Contracts.csproj Contracts/
COPY WebApplication1/WebApplication1.csproj WebApplication1/

# Restore dependencies
RUN dotnet restore WebApplication1/WebApplication1.csproj

# Copy full source code
COPY Contracts/ Contracts/
COPY WebApplication1/ WebApplication1/

# Build project
WORKDIR /src/WebApplication1
RUN dotnet build -c $BUILD_CONFIGURATION --no-restore -v m -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish WebApplication1.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]