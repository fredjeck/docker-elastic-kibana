FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.csproj ./
# Restore as distinct layers
RUN dotnet restore
# Copy everything
COPY . ./
# Build and publish a release
RUN dotnet build -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN groupadd -r dotnet && useradd --no-log-init -r -g dotnet dotnet
USER dotnet
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "StructuredLogging.dll"]