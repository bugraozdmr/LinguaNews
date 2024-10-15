FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LinguaNews.Api/LinguaNews.Api.csproj", "LinguaNews.Api/"]
COPY ["LinguaNews.Infrastructure/LinguaNews.Infrastructure.csproj", "LinguaNews.Infrastructure/"]
COPY ["LinguaNews.Domain/LinguaNews.Domain.csproj", "LinguaNews.Domain/"]
COPY ["LinguaNews.Application/LinguaNews.Application.csproj", "LinguaNews.Application/"]
COPY ["../BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "../BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "LinguaNews.Api/LinguaNews.Api.csproj"
COPY . .
WORKDIR "/src/LinguaNews.Api"
RUN dotnet build "LinguaNews.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LinguaNews.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinguaNews.Api.dll"]
