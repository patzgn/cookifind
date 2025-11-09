FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5044

ENV ASPNETCORE_URLS=http://+:5044

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CookiFind.Web.Blazor/CookiFind.Web.Blazor.csproj", "CookiFind.Web.Blazor/"]
RUN dotnet restore "CookiFind.Web.Blazor/CookiFind.Web.Blazor.csproj"
COPY . .
WORKDIR "/src/CookiFind.Web.Blazor"
RUN dotnet build "CookiFind.Web.Blazor.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CookiFind.Web.Blazor.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookiFind.Web.Blazor.dll"]
