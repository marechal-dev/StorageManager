FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StorageManager.API/StorageManager.API.csproj", "StorageManager.API/"]
RUN dotnet restore "StorageManager.API/StorageManager.API.csproj"
COPY . .
WORKDIR "/src/StorageManager.API"
RUN dotnet build "StorageManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StorageManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StorageManager.API.dll"]