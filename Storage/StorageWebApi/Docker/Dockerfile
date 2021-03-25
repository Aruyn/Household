FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StorageWebApi.csproj", "./"]
RUN dotnet restore "StorageWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StorageWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StorageWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StorageWebApi.dll"]
