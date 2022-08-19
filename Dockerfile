#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BaseService.Api/BaseService.Api.csproj", "BaseService.Api/"]
COPY ["BaseService.Services/BaseService.Services.csproj", "BaseService.Services/"]
COPY ["BaseService.Core/BaseService.Core.csproj", "BaseService.Core/"]
COPY ["BaseService.Data/BaseService.Data.csproj", "BaseService.Data/"]
RUN dotnet restore "BaseService.Api/BaseService.Api.csproj"
COPY . .
WORKDIR "/src/BaseService.Api"
RUN dotnet build "BaseService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseService.Api.dll"]
