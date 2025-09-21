FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos .csproj
COPY ["src/TrackingCompanies.Api/TrackingCompanies.Api.csproj", "src/TrackingCompanies.Api/"]
COPY ["src/TrackingCompanies.Application/TrackingCompanies.Application.csproj", "src/TrackingCompanies.Application/"]
COPY ["src/TrackingCompanies.Domain/TrackingCompanies.Domain.csproj", "src/TrackingCompanies.Domain/"]
COPY ["src/TrackingCompanies.Infrastructure/TrackingCompanies.Infrastructure.csproj", "src/TrackingCompanies.Infrastructure/"]

# Restaurar pacotes
RUN dotnet restore "src/TrackingCompanies.Api/TrackingCompanies.Api.csproj"

# Copiar todo o código fonte
COPY . .

# Build da aplicação
WORKDIR "/src/src/TrackingCompanies.Api"
RUN dotnet build "TrackingCompanies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrackingCompanies.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrackingCompanies.Api.dll"]