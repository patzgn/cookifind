FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CookiFind.Web.Blazor/CookiFind.Web.Blazor.csproj", "CookiFind.Web.Blazor/"]
RUN dotnet restore "CookiFind.Web.Blazor/CookiFind.Web.Blazor.csproj"
COPY . .
WORKDIR "/src/CookiFind.Web.Blazor"
RUN dotnet build "./CookiFind.Web.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CookiFind.Web.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookiFind.Web.Blazor.dll"]
