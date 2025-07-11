# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY KashtoCash/*.csproj ./KashtoCash/
RUN dotnet restore

# Copy everything else and build
COPY KashtoCash/. ./KashtoCash/
WORKDIR /source/KashtoCash
RUN dotnet publish -c Release -o /app/publish

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (optional for local testing)
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "KashtoCash.dll"]
