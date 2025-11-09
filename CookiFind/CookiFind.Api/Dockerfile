FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CookiFind.Api/CookiFind.Api.csproj", "CookiFind.Api/"]
COPY ["CookiFind.Application/CookiFind.Application.csproj", "CookiFind.Application/"]
COPY ["CookiFind.Contracts/CookiFind.Contracts.csproj", "CookiFind.Contracts/"]
RUN dotnet restore "CookiFind.Api/CookiFind.Api.csproj"
COPY . .
WORKDIR "/src/CookiFind.Api"
RUN dotnet build "CookiFind.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CookiFind.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookiFind.Api.dll"]
