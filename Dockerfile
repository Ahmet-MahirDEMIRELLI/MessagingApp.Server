# Use the official .NET 9 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy all csproj files and restore dependencies
COPY MessagingApp.Api/*.csproj ./MessagingApp.Api/
COPY MessagingApp.Application/*.csproj ./MessagingApp.Application/
COPY MessagingApp.Domain/*.csproj ./MessagingApp.Domain/
COPY MessagingApp.Infrastructure/*.csproj ./MessagingApp.Infrastructure/

# Restore all projects
RUN dotnet restore MessagingApp.Api/MessagingApp.Api.csproj

# Copy everything else and build the release version
COPY . .

WORKDIR /src/MessagingApp.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app
COPY --from=build /app/publish .

# Expose port
EXPOSE 5000

# Run the API
ENTRYPOINT ["dotnet", "MessagingApp.Api.dll"]
