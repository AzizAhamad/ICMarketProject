#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ICMarkets.API/ICMarkets.API.csproj", "ICMarkets.API/"]
COPY ["ICMarkets.Core/ICMarkets.Core.csproj", "ICMarkets.Core/"]
COPY ["ICMarkets.Application/ICMarkets.Application.csproj", "ICMarkets.Application/"]
RUN dotnet restore "ICMarkets.API/ICMarkets.API.csproj"
COPY . .
WORKDIR "/src/ICMarkets.API"
RUN dotnet build "ICMarkets.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ICMarkets.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ICMarkets.API.dll"]
