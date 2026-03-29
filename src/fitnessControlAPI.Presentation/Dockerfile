FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/fitnessControlAPI.Presentation/fitnessControlAPI.Presentation.csproj", "src/fitnessControlAPI.Presentation/"]
COPY ["src/fitnessControlAPI.Application/fitnessControlAPI.Application.csproj", "src/fitnessControlAPI.Application/"]
COPY ["src/fitnessControlAPI.Domain/fitnessControlAPI.Domain.csproj", "src/fitnessControlAPI.Domain/"]
COPY ["src/fitnessControlAPI.Infrastructure/fitnessControlAPI.Infrastructure.csproj", "src/fitnessControlAPI.Infrastructure/"]
COPY ["src/fitnessControlAPI.Persistence/fitnessControlAPI.Persistence.csproj", "src/fitnessControlAPI.Persistence/"]
RUN dotnet restore "src/fitnessControlAPI.Presentation/fitnessControlAPI.Presentation.csproj"
COPY . .
WORKDIR "/src/src/fitnessControlAPI.Presentation"
RUN dotnet build "./fitnessControlAPI.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./fitnessControlAPI.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fitnessControlAPI.Presentation.dll"]
