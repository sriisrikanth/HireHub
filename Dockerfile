# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy entire repository
COPY . .

# Restore solution
RUN dotnet restore main/HireHub.sln

# Publish API project
RUN dotnet publish main/HireHub.Api/HireHub.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "HireHub.Api.dll"]
