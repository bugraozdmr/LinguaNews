FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projeleri doğru dizinlere kopyalayın
COPY ["LinguaNews/LinguaNews.Api/LinguaNews.Api.csproj", "LinguaNews/LinguaNews.Api/"]
COPY ["LinguaNews/LinguaNews.Infrastructure/LinguaNews.Infrastructure.csproj", "LinguaNews/LinguaNews.Infrastructure/"]
COPY ["LinguaNews/LinguaNews.Domain/LinguaNews.Domain.csproj", "LinguaNews/LinguaNews.Domain/"]
COPY ["LinguaNews/LinguaNews.Application/LinguaNews.Application.csproj", "LinguaNews/LinguaNews.Application/"]
COPY ["BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/"]

# Restore işlemi
RUN dotnet restore "LinguaNews/LinguaNews.Api/LinguaNews.Api.csproj"

# Proje dosyalarını kopyalayın (önceki COPY sadece .csproj dosyalarını kopyalıyordu)
COPY LinguaNews/ LinguaNews/
COPY BuildingBlocks/ BuildingBlocks/

# LinguaNews.Api dizinine geçin
WORKDIR "/src/LinguaNews/LinguaNews.Api"

# Build işlemi
RUN dotnet build "LinguaNews.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LinguaNews.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinguaNews.Api.dll"]
