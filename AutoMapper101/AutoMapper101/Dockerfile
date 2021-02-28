#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0.102-ca-patch-buster-slim AS build
WORKDIR /src
COPY ["AutoMapper101/AutoMapper101.csproj", "AutoMapper101/"]
RUN dotnet restore "AutoMapper101/AutoMapper101.csproj"
COPY . .
WORKDIR "/src/AutoMapper101"
RUN dotnet build "AutoMapper101.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoMapper101.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoMapper101.dll"]