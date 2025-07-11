# Use official .NET 8 runtime as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage using .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore the project
COPY ["kashtocash.fsproj", "./"]
RUN dotnet restore "kashtocash.fsproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "kashtocash.fsproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "kashtocash.dll"]
